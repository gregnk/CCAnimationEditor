using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System;

namespace CCAnimationEditor
{
    public class AnimationFile
    {
        private string filePath;
        private string doctype;
        private List<Sheet> sheets = new List<Sheet>();
        private Offset offset;
        private int dirs;
        private List<Animation> animations = new List<Animation>();

        public string FilePath { get => filePath; set => filePath = value; }
        public string Doctype { get => doctype; set => doctype = value; }
        public List<Sheet> Sheets { get => sheets; set => sheets = value; }
        public Offset Offset { get => offset; set => offset = value; }
        public int Dirs { get => dirs; set => dirs = value; }
        public List<Animation> Animations { get => animations; set => animations = value; }

        // TODO: Add an option for formatting
        public void SaveFile(string fileName)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            using (JsonWriter writer = new JsonTextWriter(sw))
            {
#if DEBUG
                writer.Formatting = Formatting.Indented;
#endif

                // File begin
                writer.WriteStartObject();

                // Doctype
                writer.WritePropertyName("DOCTYPE");
                writer.WriteValue(Doctype);

                // Sheets
                writer.WritePropertyName("namedSheets");
                writer.WriteStartObject();

                foreach (Sheet sheet in Sheets)
                {
                    writer.WritePropertyName(sheet.Name);
                    writer.WriteStartObject();

                    writer.WritePropertyName("src");
                    writer.WriteValue(sheet.Src.Replace("\\/", "/"));

                    if (sheet.XCount > 0)
                    {
                        writer.WritePropertyName("xCount");
                        writer.WriteValue(sheet.XCount);
                    }

                    writer.WritePropertyName("offX");
                    writer.WriteValue(sheet.OffX);

                    writer.WritePropertyName("offY");
                    writer.WriteValue(sheet.OffY);

                    writer.WritePropertyName("width");
                    writer.WriteValue(sheet.Width);

                    writer.WritePropertyName("height");
                    writer.WriteValue(sheet.Height);

                    writer.WriteEndObject();
                }

                // Sheets end
                writer.WriteEndObject();

                // Offset
                // TODO: Actually implement the Offset value into the editor
                if (Offset != null)
                {
                    writer.WritePropertyName("x");
                    writer.WriteValue(Offset.X);

                    writer.WritePropertyName("y");
                    writer.WriteValue(Offset.Y);

                    writer.WritePropertyName("z");
                    writer.WriteValue(Offset.Z);
                }

                // Offset end
                writer.WriteEndObject();

                // Sort the SUBs
                var sub1 = Animations.GroupBy(anim => new { anim.Sheet, anim.Dirs, anim.ShapeType });

                // SUB 1
                writer.WritePropertyName("SUB");
                writer.WriteStartArray();

                foreach (var group in sub1)
                {
                    var groupList = group.ToList();

                    writer.WriteStartObject();

                    writer.WritePropertyName("sheet");
                    writer.WriteValue(groupList[0].Sheet);

                    writer.WritePropertyName("shapeType");
                    writer.WriteValue(groupList[0].ShapeType);

                    if (groupList[0].Dirs != 0)
                    {
                        writer.WritePropertyName("dirs");
                        writer.WriteValue(groupList[0].Dirs);
                    }

                    // Sort again
                    var sub2 = groupList.GroupBy(anim => new { anim.FlipX, anim.TileOffsets, anim.AnchorOffsetX, anim.AnchorOffsetY, anim.AnchorOffsetZ });

                    // SUB 2
                    writer.WritePropertyName("SUB");
                    writer.WriteStartArray();
                    foreach (var group2 in sub2)
                    {
                        writer.WriteStartObject();

                        var groupList2 = group2.ToList();

                        // Output a default value if the group's var is null

                        // FlipX
                        if (groupList2[0].FlipX != null)
                        {
                            writer.WritePropertyName("flipX");
                            WriteIntArray(writer, groupList2[0].FlipX);
                        }

                        else
                        {
                            writer.WritePropertyName("flipX");
                            WriteIntArray(writer, new int[] { 0 });
                        }

                        // TileOffsets
                        if (groupList2[0].TileOffsets != null)
                        {
                            writer.WritePropertyName("tileOffsets");
                            WriteIntArray(writer, groupList2[0].TileOffsets);
                        }

                        else
                        {
                            writer.WritePropertyName("tileOffsets");
                            WriteIntArray(writer, new int[] { 0 });
                        }

                        // AnchorOffsetX
                        if (groupList2[0].AnchorOffsetX != null)
                        {
                            writer.WritePropertyName("anchorOffsetX");
                            WriteIntArray(writer, groupList2[0].AnchorOffsetX);
                        }

                        else
                        {
                            writer.WritePropertyName("anchorOffsetX");
                            WriteIntArray(writer, new int[] { 0 });
                        }

                        // AnchorOffsetY
                        if (groupList2[0].AnchorOffsetY != null)
                        {
                            writer.WritePropertyName("anchorOffsetY");
                            WriteIntArray(writer, groupList2[0].AnchorOffsetY);
                        }

                        else
                        {
                            writer.WritePropertyName("anchorOffsetY");
                            WriteIntArray(writer, new int[] { 0 });
                        }

                        // AnchorOffsetZ
                        if (groupList2[0].AnchorOffsetY != null)
                        {
                            writer.WritePropertyName("anchorOffsetZ");
                            WriteIntArray(writer, groupList2[0].AnchorOffsetZ);
                        }

                        else
                        {
                            writer.WritePropertyName("anchorOffsetZ");
                            WriteIntArray(writer, new int[] { 0 });
                        }

                        // SUB 3
                        writer.WritePropertyName("SUB");
                        writer.WriteStartArray();

                        foreach (Animation anim in groupList2)
                        {
                            writer.WriteStartObject();

                            writer.WritePropertyName("name");
                            writer.WriteValue(anim.Name);

                            writer.WritePropertyName("time");
                            writer.WriteValue(anim.Time);

                            writer.WritePropertyName("repeat");
                            writer.WriteValue(anim.Repeat);

                            if (anim.Frames != null)
                            {
                                writer.WritePropertyName("frames");
                                WriteIntArray(writer, anim.Frames);
                            }

                            if (anim.DirFrames != null)
                            {
                                writer.WritePropertyName("dirFrames");
                                Write2dIntArray(writer, anim.DirFrames);
                            }

                            writer.WriteEndObject();
                        }

                        writer.WriteEndArray();
                        writer.WriteEndObject();
                    }

                    // SUB 2 end
                    writer.WriteEndArray();

                    writer.WriteEndObject();
                }

                // SUB 1 end
                writer.WriteEndArray();

                // File end
                writer.WriteEndObject();
            }

            File.WriteAllText(fileName, sb.ToString());
        }

        public bool LoadFile(string filePath)
        {
            JObject animJsonObj = JObject.Parse(File.ReadAllText(filePath));
            FilePath = filePath;

            // Animation data
            AnimationFile animationFileData = animJsonObj.ToObject<AnimationFile>();
            Doctype = animationFileData.Doctype;

            // File not supported
            if (animationFileData.Doctype != "MULTI_DIR_ANIMATION")
            {
                return false;
            }

            else
            {
                try
                {
                    Offset = animationFileData.Offset;

                    // Sheets
                    IList<JToken> sheetsJson = animJsonObj["namedSheets"].Children().ToList();
                    foreach (JToken sheetJson in sheetsJson)
                    {
                        Sheet sheet = new Sheet();
                        sheet = sheetJson.First.ToObject<Sheet>();

                        // Sheet name
                        JProperty sheetProp = sheetJson.ToObject<JProperty>();
                        sheet.Name = sheetProp.Name;

                        // Add the sheet to the list
                        Sheets.Add(sheet);
                    }


                    // Animations
                    List<Animation> animations = new List<Animation>();

                    // What this does is fill in null values from each SUB layer
                    // For int values, a default value of -1 is used to indicate that the value is not set in the JSON

                    // Toplevel
                    Animation animationTopLevel = animJsonObj.ToObject<Animation>();

                    // SUB 1 Items
                    IList<JToken> sub1 = animJsonObj["SUB"].Children().ToList();
                    foreach (JToken sub1Item in sub1)
                    {
                        Animation animSub1 = sub1Item.ToObject<Animation>();

                        // SUB 2 Items
                        IList<JToken> sub2 = sub1Item["SUB"].Children().ToList();
                        foreach (JToken sub2Item in sub2)
                        {
                            Animation animSub2 = sub2Item.ToObject<Animation>();

                            if (sub2Item["SUB"] != null)
                            {
                                // SUB 3 Items
                                IList<JToken> sub3 = sub2Item["SUB"].Children().ToList();
                                foreach (JToken sub3Item in sub3)
                                {
                                    Animation animSub3 = sub3Item.ToObject<Animation>();
                                    Animation anim = new Animation();

                                    foreach (var prop in anim.GetType().GetProperties())
                                    {
                                        if (animationTopLevel.GetType().GetProperty(prop.Name).GetValue(animationTopLevel) != null)
                                        {
                                            if (animationTopLevel.GetType().GetProperty(prop.Name).GetValue(animationTopLevel).ToString() != "-1")
                                                prop.SetValue(anim, animationTopLevel.GetType().GetProperty(prop.Name).GetValue(animationTopLevel));
                                        }

                                        if (animSub1.GetType().GetProperty(prop.Name).GetValue(animSub1) != null)
                                        {
                                            if (animSub1.GetType().GetProperty(prop.Name).GetValue(animSub1).ToString() != "-1")
                                                prop.SetValue(anim, animSub1.GetType().GetProperty(prop.Name).GetValue(animSub1));
                                        }

                                        if (animSub2.GetType().GetProperty(prop.Name).GetValue(animSub2) != null)
                                        {
                                            if (animSub1.GetType().GetProperty(prop.Name).GetValue(animSub2).ToString() != "-1")
                                                prop.SetValue(anim, animSub2.GetType().GetProperty(prop.Name).GetValue(animSub2));
                                        }

                                        if (animSub3.GetType().GetProperty(prop.Name).GetValue(animSub3) != null)
                                        {
                                            if (animSub3.GetType().GetProperty(prop.Name).GetValue(animSub3).ToString() != "-1")
                                                prop.SetValue(anim, animSub3.GetType().GetProperty(prop.Name).GetValue(animSub3));
                                        }
                                    }


                                    animations.Add(anim);
                                }
                            }

                            else
                            {
                                Animation anim = new Animation();

                                foreach (var prop in anim.GetType().GetProperties())
                                {
                                    if (animationTopLevel.GetType().GetProperty(prop.Name).GetValue(animationTopLevel) != null)
                                    {
                                        if (animationTopLevel.GetType().GetProperty(prop.Name).GetValue(animationTopLevel).ToString() != "-1")
                                            prop.SetValue(anim, animationTopLevel.GetType().GetProperty(prop.Name).GetValue(animationTopLevel));
                                    }

                                    if (animSub1.GetType().GetProperty(prop.Name).GetValue(animSub1) != null)
                                    {
                                        if (animSub1.GetType().GetProperty(prop.Name).GetValue(animSub1).ToString() != "-1")
                                            prop.SetValue(anim, animSub1.GetType().GetProperty(prop.Name).GetValue(animSub1));
                                    }

                                    if (animSub2.GetType().GetProperty(prop.Name).GetValue(animSub2) != null)
                                    {
                                        if (animSub1.GetType().GetProperty(prop.Name).GetValue(animSub2).ToString() != "-1")
                                            prop.SetValue(anim, animSub2.GetType().GetProperty(prop.Name).GetValue(animSub2));
                                    }
                                }

                                animations.Add(anim);
                            }
                        }
                    }

                    Animations = animations;
                    return true;
                }

                catch (Exception e)
                {
                    Program.WriteExecptionOutputToConsole(e);
                    return false;
                }
            }
        }

        public Sheet FindSheet(string name)
        {
            foreach (Sheet sheet in Sheets)
            {
                if (sheet.Name == name)
                    return sheet;
            }

            return null;
        }

        public void CreateBackup()
        {
            File.Copy(filePath, Path.ChangeExtension(filePath, string.Format(".backup{0}.json", DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss"))));
        }

        private void WriteIntArray(JsonWriter writer, int[] array)
        {
            writer.WriteStartArray();

            foreach (int num in array)
            {
                writer.WriteValue(num);
            }

            writer.WriteEndArray();
        }

        private void Write2dIntArray(JsonWriter writer, int[][] array)
        {
            writer.WriteStartArray();

            foreach (int[] array2 in array)
            {
                WriteIntArray(writer, array2);
            }

            writer.WriteEndArray();
        }
    }
}
