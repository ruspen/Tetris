using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris.GameModule
{
    public class GameData
    {
        public const int GRID_WIDTH = 10;
        public const int GRID_HEIGHT = 20;

        public const string SPAWNER_PREFAB_PATH = "GameModule/Spawner";
        public const string GROUP_CONTROLLER_PREFAB_PATH = "GameModule/GroupController";

        public const int SCORE_INCREASE = 10;

        public static int CurrentScore = 0;
    }
}

