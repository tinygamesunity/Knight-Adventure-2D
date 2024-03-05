using UnityEngine;

namespace KnightAdventure.Utils {

    public static class Utils {


        public static Vector3 GetRandomDir() {
            return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        }

    }

}
