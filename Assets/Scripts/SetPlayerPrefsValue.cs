namespace UnityEngine.Events
{
    public enum ePlayerPrefsValType
    {
        FloatValue,
        IntValue,
        StringValue
    }
    
    public class SetPlayerPrefsValue : MonoBehaviour
    {
        public string key;
        public ePlayerPrefsValType ValType;
        public float valueFloat;
        public int valueInt;
        public string valueString;

        public void SetVal()
        {
            switch (ValType)
            {
                case ePlayerPrefsValType.IntValue:
                    PlayerPrefs.SetInt(key, valueInt);
                    break;
                case ePlayerPrefsValType.FloatValue:
                    PlayerPrefs.SetFloat(key, valueFloat);
                    break;
                case ePlayerPrefsValType.StringValue:
                    PlayerPrefs.SetString(key, valueString);
                    break;
            }
            
            PlayerPrefs.Save();
        }
    }
}