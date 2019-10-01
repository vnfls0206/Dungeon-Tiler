using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCast
{
    private MapManager MapManager;
    private int visrange, visrange2;
    private int PlayerX, PlayerY;

    public ShadowCast(MapManager mapmanager)
    {
        this.MapManager = mapmanager;
    }

    public void ScanOctant(int Visrange, Vector3 PlayerPosition, Sight_Sort Sight_Sort, Tile[,] MapData, 
        int pDepth, int pOctant, double pStartSlope, double pEndSlope)
    {
        visrange = Visrange;
        visrange2 = visrange * visrange;      //시야 x 시야
        PlayerX = (int)PlayerPosition.x;
        PlayerY = (int)PlayerPosition.y;

        ScanArround(Sight_Sort, MapData, pDepth, pOctant, pStartSlope, pEndSlope);
    }


    private void ScanArround(Sight_Sort Sight_Sort, Tile[,] MapData, int pDepth, int pOctant, double pStartSlope, double pEndSlope)
    {

        int x = 0;                                                                      //x값 초기화
        int y = 0;                                                                      //y값 초기화

        switch (pOctant)        //FOW에서 호출될때 사용된 8방위에 따라 진행된다.
        {

            case 1: //                      x -1, y - 1
                y = PlayerY - pDepth;
                if (y < 0) return;

                x = PlayerX - Convert.ToInt32((pStartSlope * Convert.ToDouble(pDepth)));        //시작시의 기울기
                if (x < 0) x = 0;

                while (GetSlope(x, y, PlayerX, PlayerY, false) >= pEndSlope)        //기울기가 0보다 크거나 같으면 반복
                {

                    if (GetVisDistance(x, y, PlayerX, PlayerY) < visrange2)     //대상과의 거리가, Range보다 작을때
                    {
                        if (!MapManager.Is_Move_Able_Tile(MapManager.GetTile(x, y).Tile_Sort)) // 해당좌표가 tile이 아닐때
                        {
                            if (x - 1 >= 0 &&
                                MapManager.Is_Move_Able_Tile(MapManager.GetTile(x - 1 , y).Tile_Sort))    //해당좌표가 tile이거나
                                // 대상의 x좌표가 1보다 같거나 커야하고, x-1 좌표는 타일일때 
                                ScanArround(Sight_Sort, MapData, pDepth + 1, pOctant, pStartSlope, GetSlope(x - 0.5, y + 0.5, PlayerX, PlayerY, false));

                            MapData[x, y].Sight_Sort = Sight_Sort;

                        }
                        else
                        {                       // 해당 좌표가 tile 일때

                            if (x - 1 >= 0 && !MapManager.Is_Move_Able_Tile(MapManager.GetTile(x - 1, y).Tile_Sort))     //옆이 벽이면
                                                                                                                        //..adjust the startslope
                                pStartSlope = GetSlope(x - 0.5, y - 0.5, PlayerX, PlayerY, false);  //대각선 아래

                            //VisiblePoints.Add(new Point(x, y));
                            MapData[x, y].Sight_Sort = Sight_Sort;
                        }
                    }

                    x++;    //x값의 증가
                }
                x--;
                break;

            case 2: //nne

                y = PlayerY - pDepth;
                if (y < 0) return;

                x = PlayerX + Convert.ToInt32((pStartSlope * Convert.ToDouble(pDepth)));

                if (x >= MapManager.MapSize + 1)
                    x = MapManager.MapSize + 1;

                while (GetSlope(x, y, PlayerX, PlayerY, false) <= pEndSlope)
                {
                    if (GetVisDistance(x, y, PlayerX, PlayerY) < visrange2)
                    {
                        if (!MapManager.Is_Move_Able_Tile(MapManager.GetTile(x, y).Tile_Sort))
                        {
                            if (x + 1 < MapManager.MapSize + 1 &&
                                (MapManager.Is_Move_Able_Tile(MapManager.GetTile(x + 1, y).Tile_Sort)))        //해당좌표가 tile이거나 

                                ScanArround(Sight_Sort, MapData, pDepth + 1, pOctant, pStartSlope, GetSlope(x + 0.5, y + 0.5, PlayerX, PlayerY, false));
                            MapData[x, y].Sight_Sort = Sight_Sort;
                        }
                        else
                        {
                            if (x + 1 < MapManager.MapSize + 1 && !MapManager.Is_Move_Able_Tile(MapManager.GetTile(x + 1, y).Tile_Sort))
                                pStartSlope = -GetSlope(x + 0.5, y - 0.5, PlayerX, PlayerY, false);

                            //VisiblePoints.Add(new Point(x, y));
                            MapData[x, y].Sight_Sort = Sight_Sort;
                        }
                    }
                    x--;
                }
                x++;
                break;

            case 3:

                x = PlayerX + pDepth;
                if (x >= MapManager.MapSize + 1) return;

                y = PlayerY - Convert.ToInt32((pStartSlope * Convert.ToDouble(pDepth)));
                if (y < 0) y = 0;

                while (GetSlope(x, y, PlayerX, PlayerY, true) <= pEndSlope)
                {

                    if (GetVisDistance(x, y, PlayerX, PlayerY) < visrange2)
                    {

                        if (!MapManager.Is_Move_Able_Tile(MapManager.GetTile(x, y).Tile_Sort))
                        {
                            if (y - 1 >= 0 &&
                                (MapManager.Is_Move_Able_Tile(MapManager.GetTile(x, y - 1).Tile_Sort)))
                                ScanArround(Sight_Sort, MapData, pDepth + 1, pOctant, pStartSlope, GetSlope(x - 0.5, y - 0.5, PlayerX, PlayerY, true));
                            MapData[x, y].Sight_Sort = Sight_Sort;
                        }
                        else
                        {
                            if (y - 1 >= 0 && !MapManager.Is_Move_Able_Tile(MapManager.GetTile(x, y - 1).Tile_Sort))
                                pStartSlope = -GetSlope(x + 0.5, y - 0.5, PlayerX, PlayerY, true);

                            //VisiblePoints.Add(new Point(x, y));
                            MapData[x, y].Sight_Sort = Sight_Sort;
                        }
                    }
                    y++;
                }
                y--;
                break;

            case 4:

                x = PlayerX + pDepth;
                if (x >= MapManager.MapSize + 1) return;

                y = PlayerY + Convert.ToInt32((pStartSlope * Convert.ToDouble(pDepth)));
                if (y >= MapManager.MapSize + 1) y = MapManager.MapSize + 1;

                while (GetSlope(x, y, PlayerX, PlayerY, true) >= pEndSlope)
                {

                    if (GetVisDistance(x, y, PlayerX, PlayerY) < visrange2)
                    {

                        if (!MapManager.Is_Move_Able_Tile(MapManager.GetTile(x, y).Tile_Sort))
                        {
                            if (y + 1 < MapManager.MapSize + 1 &&
                                (MapManager.Is_Move_Able_Tile(MapManager.GetTile(x, y + 1).Tile_Sort)))
                                ScanArround(Sight_Sort, MapData, pDepth + 1, pOctant, pStartSlope, GetSlope(x - 0.5, y + 0.5, PlayerX, PlayerY, true));
                            MapData[x, y].Sight_Sort = Sight_Sort;
                        }
                        else
                        {
                            if (y + 1 < MapManager.MapSize + 1 && 
                                !MapManager.Is_Move_Able_Tile(MapManager.GetTile(x, y + 1).Tile_Sort))
                                pStartSlope = GetSlope(x + 0.5, y + 0.5, PlayerX, PlayerY, true);

                            //VisiblePoints.Add(new Point(x, y));
                            MapData[x, y].Sight_Sort = Sight_Sort;
                        }
                    }
                    y--;
                }
                y++;
                break;

            case 5:

                y = PlayerY + pDepth;
                if (y >= MapManager.MapSize + 1) return;

                x = PlayerX + Convert.ToInt32((pStartSlope * Convert.ToDouble(pDepth)));
                if (x >= MapManager.MapSize + 1) x = MapManager.MapSize + 1;

                while (GetSlope(x, y, PlayerX, PlayerY, false) >= pEndSlope)
                {
                    if (GetVisDistance(x, y, PlayerX, PlayerY) < visrange2)
                    {

                        if (!MapManager.Is_Move_Able_Tile(MapManager.GetTile(x, y).Tile_Sort))
                        {
                            if (x + 1 < MapManager.MapSize + 1 &&
                                (MapManager.Is_Move_Able_Tile(MapManager.GetTile(x + 1, y).Tile_Sort)))
                                ScanArround(Sight_Sort, MapData, pDepth + 1, pOctant, pStartSlope, GetSlope(x + 0.5, y - 0.5, PlayerX, PlayerY, false));
                            MapData[x, y].Sight_Sort = Sight_Sort;
                        }
                        else
                        {
                            if (x + 1 < MapManager.MapSize + 1
                                    && !MapManager.Is_Move_Able_Tile(MapManager.GetTile(x + 1, y).Tile_Sort))
                                pStartSlope = GetSlope(x + 0.5, y + 0.5, PlayerX, PlayerY, false);

                            //VisiblePoints.Add(new Point(x, y));
                            MapData[x, y].Sight_Sort = Sight_Sort;
                        }
                    }
                    x--;
                }
                x++;
                break;

            case 6:

                y = PlayerY + pDepth;
                if (y >= MapManager.MapSize + 1) return;

                x = PlayerX - Convert.ToInt32((pStartSlope * Convert.ToDouble(pDepth)));
                if (x < 0) x = 0;

                while (GetSlope(x, y, PlayerX, PlayerY, false) <= pEndSlope)
                {
                    if (GetVisDistance(x, y, PlayerX, PlayerY) < visrange2)
                    {

                        if (!MapManager.Is_Move_Able_Tile(MapManager.GetTile(x, y).Tile_Sort))
                        {
                            if (x - 1 >= 0 &&
                                (MapManager.Is_Move_Able_Tile(MapManager.GetTile(x - 1, y).Tile_Sort)))
                                ScanArround(Sight_Sort, MapData, pDepth + 1, pOctant, pStartSlope, GetSlope(x - 0.5, y - 0.5, PlayerX, PlayerY, false));
                            MapData[x, y].Sight_Sort = Sight_Sort;
                        }
                        else
                        {
                            if (x - 1 >= 0
                                    && !MapManager.Is_Move_Able_Tile(MapManager.GetTile(x - 1, y).Tile_Sort))
                                pStartSlope = -GetSlope(x - 0.5, y + 0.5, PlayerX, PlayerY, false);

                            //VisiblePoints.Add(new Point(x, y));
                            MapData[x, y].Sight_Sort = Sight_Sort;
                        }
                    }
                    x++;
                }
                x--;
                break;

            case 7:

                x = PlayerX - pDepth;
                if (x < 0) return;

                y = PlayerY + Convert.ToInt32((pStartSlope * Convert.ToDouble(pDepth)));
                if (y >= MapManager.MapSize + 1) y = MapManager.MapSize + 1;

                while (GetSlope(x, y, PlayerX, PlayerY, true) <= pEndSlope)
                {

                    if (GetVisDistance(x, y, PlayerX, PlayerY) < visrange2)
                    {

                        if (!MapManager.Is_Move_Able_Tile(MapManager.GetTile(x, y).Tile_Sort))
                        {
                            if (y + 1 < MapManager.MapSize + 1 &&
                                (MapManager.Is_Move_Able_Tile(MapManager.GetTile(x, y + 1).Tile_Sort)))
                                ScanArround(Sight_Sort, MapData, pDepth + 1, pOctant, pStartSlope, GetSlope(x + 0.5, y + 0.5, PlayerX, PlayerY, true));
                            MapData[x, y].Sight_Sort = Sight_Sort;
                        }
                        else
                        {
                            if (y + 1 < MapManager.MapSize + 1 && !MapManager.Is_Move_Able_Tile(MapManager.GetTile(x, y + 1).Tile_Sort))
                                pStartSlope = -GetSlope(x - 0.5, y + 0.5, PlayerX, PlayerY, true);

                            //VisiblePoints.Add(new Point(x, y));
                            MapData[x, y].Sight_Sort = Sight_Sort;
                        }
                    }
                    y--;
                }
                y++;
                break;

            case 8: //wnw

                x = PlayerX - pDepth;
                if (x < 0) return;

                y = PlayerY - Convert.ToInt32((pStartSlope * Convert.ToDouble(pDepth)));
                if (y < 0) y = 0;

                while (GetSlope(x, y, PlayerX, PlayerY, true) >= pEndSlope)
                {

                    if (GetVisDistance(x, y, PlayerX, PlayerY) < visrange2)
                    {

                        if (!MapManager.Is_Move_Able_Tile(MapManager.GetTile(x, y).Tile_Sort))
                        {
                            if (y - 1 >= 0 &&
                                (MapManager.Is_Move_Able_Tile(MapManager.GetTile(x, y - 1).Tile_Sort)))
                                ScanArround(Sight_Sort, MapData, pDepth + 1, pOctant, pStartSlope, GetSlope(x + 0.5, y - 0.5, PlayerX, PlayerY, true));
                            MapData[x, y].Sight_Sort = Sight_Sort;

                        }
                        else
                        {
                            if (y - 1 >= 0 && !MapManager.Is_Move_Able_Tile(MapManager.GetTile(x, y - 1).Tile_Sort))
                                pStartSlope = GetSlope(x - 0.5, y - 0.5, PlayerX, PlayerY, true);

                            //VisiblePoints.Add(new Point(x, y));
                            MapData[x, y].Sight_Sort = Sight_Sort;
                        }
                    }
                    y++;
                }
                y--;
                break;
        }

        if (x < 0)
            x = 0;
        else if (x >= MapManager.MapSize + 1)       //맵 사이즈 만큼 최대 최소값 조절
            x = MapManager.MapSize + 1;

        if (y < 0)
            y = 0;
        else if (y >= MapManager.MapSize + 1)
            y = MapManager.MapSize + 1;

        if (pDepth < visrange &
            (MapManager.Is_Move_Able_Tile(MapManager.GetTile(x, y).Tile_Sort)))
            ScanArround(Sight_Sort, MapData, pDepth + 1, pOctant, pStartSlope, pEndSlope);

    }


    private double GetSlope(double pX1, double pY1, double pX2, double pY2, bool pInvert)   //두점의 기울기를 구하는 공식
    {
        if (pInvert)
            return (pY1 - pY2) / (pX1 - pX2);
        else
            return (pX1 - pX2) / (pY1 - pY2);
    }


    private int GetVisDistance(int pX1, int pY1, int pX2, int pY2)  //두점 사이의 거리를 구하는 공식
    {
        return ((pX1 - pX2) * (pX1 - pX2)) + ((pY1 - pY2) * (pY1 - pY2));
    }
}
