using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// Helper class to figure out how a sprite's z component should be set as they traverse a Tiled map
// Can use as a behvaior that will do the work for you each update. Note this will change your sprite's z-component value on you which may collide with other behaviours.
namespace Tiled2Unity
{
    public class SpriteDepthInMap : MonoBehaviour
    {
        [Tooltip("The TiledMap instance our sprite is interacting with.")]
        public Tiled2Unity.TiledMap AttachedMap;

        [Tooltip("Which layer on the TiledMap our sprite is interacting with. Will render above lower layers and below higher layers. Render order of Tiles on same layer will depend on location.")]
        public int InteractWithLayer;

        [Tooltip("For maps where tileset heights are different than map tile heights. Enter the tileset height here. Useful/crucial for isometric maps. Leave at default (0) if you don't care.")]
        public int TilesetHeight;

        void Start()
        {
            if (AttachedMap == null)
            {
                Debug.LogError(String.Format("Sprite must be attached to a TiledMap instance in order to calucluate the 'z-depth' on that map. Check the SpriteDepthInMap component in the Inspector."));
                return;
            }
        }

        void Update() { UpdateSpriteDepth(); }

        public void UpdateSpriteDepth()
        {
            // Put position into map space
            Vector3 spritePosition = gameObject.transform.position;
            spritePosition -= AttachedMap.gameObject.transform.position;

            // Some maps (like isometric) have a tileset height that is larger than the map tile height in order to get the isometric illusion. We need to know that difference in caluclating depth.
            if (TilesetHeight != 0)
            {
                int delta_y = AttachedMap.TileHeight - TilesetHeight;
                spritePosition.y += delta_y;
            }

            Rect mapRect = AttachedMap.GetMapRect();
            float depthPerLayer = -AttachedMap.TileHeight / mapRect.height;

            float depth_z = (spritePosition.y / AttachedMap.ExportScale / mapRect.height) + (depthPerLayer * InteractWithLayer);

            // Assign our depth value in the z component.
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, depth_z);
        }
    }
}
