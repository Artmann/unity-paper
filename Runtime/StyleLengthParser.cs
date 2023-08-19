using UnityEngine.UIElements;

namespace Paper
{
    public class StyleLengthParser
    {
        public StyleLength Parse(string originalValue)
        {
            if (originalValue.ToLower() == "auto")
            {
                return StyleKeyword.Auto;
            }

            if (originalValue.ToLower() == "null")
            {
                return StyleKeyword.Null;
            }

            if (originalValue.ToLower() == "none")
            {
                return StyleKeyword.None;
            }

            if (originalValue.ToLower() == "undefined")
            {
                return StyleKeyword.Undefined;
            }

            if (originalValue.ToLower() == "initial")
            {
                return StyleKeyword.Initial;
            }

            if (originalValue.EndsWith("%"))
            {
                var floatValue = float.Parse(originalValue.Substring(0, originalValue.Length - 1));

                return new StyleLength(new Length(floatValue, LengthUnit.Percent));
            }

            if (originalValue.EndsWith("px"))
            {
                var floatValue = float.Parse(originalValue.Substring(0, originalValue.Length - 2));

                return new StyleLength(new Length(floatValue, LengthUnit.Pixel));
            }

            return new StyleLength(new Length(float.Parse(originalValue), LengthUnit.Pixel));
        }
    }
}
