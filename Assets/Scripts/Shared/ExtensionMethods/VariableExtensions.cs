namespace Infinity.Shared { 
    public static class VariableExtensions {

        public static float Remap(this float value, float minIn, float maxIn, float minOut, float maxOut) {
            value = (value - minIn) / (maxIn - minIn) * (maxOut - minOut) + minOut;
            return value;
        }
    }
}
