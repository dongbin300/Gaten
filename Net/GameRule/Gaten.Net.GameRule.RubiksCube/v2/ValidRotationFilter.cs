namespace Gaten.Net.GameRule.RubiksCube.v2
{
    public class ValidRotationFilter
    {
        string[] rotationStrings = Array.Empty<string>();
        List<string> result = new();

        public void Load(string fileName)
        {
            rotationStrings = File.ReadAllLines(fileName);
        }

        public void Save(string fileName)
        {
            File.WriteAllLines(fileName, result);
        }

        public void Filtering()
        {
            foreach (string rotation in rotationStrings)
            {
                if (IsValidRotation(rotation))
                {
                    result.Add(rotation);
                }
            }
        }

        private bool IsValidRotation(string rotationString)
        {
            List<string> rotations = new();
            for (int i = 0; i < rotationString.Length; i++)
            {
                if (i + 1 < rotationString.Length)
                {
                    if (rotationString[i + 1] == '\'' || rotationString[i + 1] == '2')
                    {
                        rotations.Add(rotationString[i..(i + 2)]);
                        i++;
                        continue;
                    }
                }
                rotations.Add(rotationString[i].ToString());
            }

            int rnum = 0;
            int unum = 0;
            foreach (var rotation in rotations)
            {
                if (rotation.Length == 1)
                {
                    if (rotation[0] == 'R')
                    {
                        rnum++;
                    }
                    else if (rotation[0] == 'U')
                    {
                        unum++;
                    }
                }
                else if (rotation.Length == 2)
                {
                    if (rotation[1] == '\'')
                    {
                        if (rotation[0] == 'R')
                        {
                            rnum--;
                        }
                        else if (rotation[0] == 'U')
                        {
                            unum--;
                        }
                    }
                    else if (rotation[1] == '2')
                    {
                        if (rotation[0] == 'R')
                        {
                            rnum += 2;
                        }
                        else if (rotation[0] == 'U')
                        {
                            unum += 2;
                        }
                    }
                }
            }
            return rnum % 4 == 0 && unum % 4 == 0;
        }
    }
}
