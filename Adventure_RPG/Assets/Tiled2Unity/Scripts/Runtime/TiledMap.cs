using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Tiled2Unity
{
    public class TiledMap : MonoBehaviour
    {
        public enum MapOrientation
        {
            Orthogonal,
            Isometric,
            Staggered,
            Hexagonal,
        }

        public enum MapStaggerAxis
        {
            X,
            Y,
        }

        public enum MapStaggerIndex
        {
            Odd,
            Even,
        }

        public MapOrientation Orientation = MapOrientation.Orthogonal;
        public MapStaggerAxis StaggerAxis = MapStaggerAxis.X;
        public MapStaggerIndex StaggerIndex = MapStaggerIndex.Odd;
        public int HexSideLength;

        public int NumLayers;
        public int NumTilesWide;
        public int NumTilesHigh;
        public int TileWidth;
        public int TileHeight;
        public float ExportScale = 1.0f;

        // Note: Because maps can be isometric and staggered we simply can't multiply tile width (or height) by number of tiles wide (or high) to get width (or height)
        // We rely on the exporter to calculate the width and height of the map
        public int MapWidthInPixels;
        public int MapHeightInPixels;

        // Background color could be used to set the camera clear color to get the same effect as in Tiled
        public Color BackgroundColor = Color.black;

        public float GetMapWidthInPixelsScaled()
        {
            return MapWidthInPixels * transform.lossyScale.x * ExportScale;
        }

        public float GetMapHeightInPixelsScaled()
        {
            return MapHeightInPixels * transform.lossyScale.y * ExportScale;
        }

        public Rect GetMapRect()
        {
            Vector2 pos_w = gameObject.transform.position;
            float width = MapWidthInPixels;
            float height = MapHeightInPixels;
            return new Rect(pos_w.x, pos_w.y - height, width, height);
        }

        public Rect GetMapRectInPixelsScaled()
        {
            Vector2 pos_w = gameObject.transform.position;
            float widthInPixels = GetMapWidthInPixelsScaled();
            float heightInPixels = GetMapHeightInPixelsScaled();
            return new Rect(pos_w.x, pos_w.y - heightInPixels, widthInPixels, heightInPixels);
        }

        public bool AreTilesStaggered()
        {
            // Hex and Iso Staggered maps both use "staggered" tiles
            return Orientation == MapOrientation.Staggered || Orientation == MapOrientation.Hexagonal;
        }

        void OnDrawGizmosSelected()
        {
            Vector3 pos_w = gameObject.transform.position;
            Vector3 topLeft = Vector3.zero + pos_w;
            Vector3 topRight = new Vector3(GetMapWidthInPixelsScaled(), 0) + pos_w;
            Vector3 bottomRight = new Vector3(GetMapWidthInPixelsScaled(), -GetMapHeightInPixelsScaled()) + pos_w;
            Vector3 bottomLeft = new Vector3(0, -GetMapHeightInPixelsScaled()) + pos_w;

            // To make gizmo visible, even when using depth-shader shaders, we decrease the z depth by the number of layers
            float depth_z = -1.0f * NumLayers;
            pos_w.z += depth_z;
            topLeft.z += depth_z;
            topRight.z += depth_z;
            bottomRight.z += depth_z;
            bottomLeft.z += depth_z;

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(topLeft, topRight);
            Gizmos.DrawLine(topRight, bottomRight);
            Gizmos.DrawLine(bottomRight, bottomLeft);
            Gizmos.DrawLine(bottomLeft, topLeft);
        }
    }
}
