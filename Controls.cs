using System.Collections.Generic;
using System.Collections;
using Newtonsoft.Json;
using UnityEngine;
using System.IO;

namespace PrincessApollo
{
    namespace Controls
    {
        public static class Controls
        {
            public static ControlScheme Scheme
            {
                get
                {
                    if (scheme != null) return scheme;
                    else
                    {
                        var path = UnityEngine.Application.dataPath + "/controls.ctrl";
                        if (!File.Exists(path))
                        {
                            File.WriteAllText(path, "{\"keys\": {\"PlayerOne-Forward\": \"W\",\"PlayerOne-Back\": \"S\",\"PlayerOne-Left\": \"A\",\"PlayerOne-Right\": \"D\",\"PlayerOne-Punch\": \"LeftAlt\",\"PlayerTwo-Forward\": \"UpArrow\",\"PlayerTwo-Back\": \"DownArrow\",\"PlayerTwo-Left\": \"LeftArrow\",\"PlayerTwo-Right\": \"RightArrow\",\"PlayerTwo-Punch\": \"RightAlt\"}}");
                            Debug.Log(path + " has been created");
                        }
                        scheme = JsonConvert.DeserializeObject<ControlScheme>(File.ReadAllText(path));
                        return scheme;
                    }

                }
                internal set
                {
                    scheme = value;
                }
            }
            private static ControlScheme scheme;
        }
        [System.Serializable]
        public class ControlScheme
        {
            [JsonProperty]
            public Dictionary<string, string> keys;
            public ControlScheme(Dictionary<string, string> keys) => this.keys = keys;
        }
    }
}