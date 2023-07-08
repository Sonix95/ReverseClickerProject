using System.Collections.Generic;
using Models;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "WavesConfig", menuName = "Configs/Create WavesConfig")]
    public class WavesConfig : ScriptableObject
    {
        public List<WaveModel> Waves;
    }
}