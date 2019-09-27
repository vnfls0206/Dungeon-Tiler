using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Node       //클래스 Node 선언(이게 List선언할때는 Struct보다 훨씬 간편한듯)
{                          
    public TIle_Data tile;                       // H = 노드와 도착점까지의 단순거리(대각선, 장애물 무시)
    public int F, G, H;                     // G = 시작부터 현재 노드까지의 이동 비용
                                            // F = G + H
}


public class A_Star
{
    private MapManager MapManager;
    public A_Star(MapManager mapmanager)
    {
        this.MapManager = mapmanager;
    }


    private TIle_Data[,] MapData;

    int Selected_Tile_Num;


    public List<TIle_Data> A_star(TIle_Data Start_Position, TIle_Data Dex_Position, TIle_Data[,] mapdata)
    {

        Dictionary<TIle_Data, TIle_Data> Parent = new Dictionary<TIle_Data, TIle_Data>();   //값, 부모
        List<TIle_Data> Reverse_Tile = new List<TIle_Data>();   //경로를 반대로 뒤집어주기 위한 과정에서, 최선의 경로만을 저장해준다.
        var ClosedList = new List<Node>();                              //닫힌 목록
        var OpenList = new List<Node>();                                //열린목록
        this.MapData = mapdata;

        Node Target_node;                                                   //선택된 노드
        Target_node = new Node { tile = Start_Position, F = 0, G = 0, H = 0 }; //시작점의 노드 초기값부여

        OpenList.Add(Target_node);          //열린목록에 시작점 넣음
        Parent.Add(Start_Position, null);       //시작점의 부모를 null로 지정

        while (Target_node.tile != Dex_Position)     //선택된 노드가 도착점이 될때까지 반복
        {
            OpenList.Remove(Target_node);           //열린목록에서 선택된 노드를 제거
            ClosedList.Add(Target_node);            //닫힌목록에 선택된 노드를 추가
            Add_Surrounds(Parent, OpenList, ClosedList, Target_node, Dex_Position);
            //선택된 노드의 주변 노드를 검사하여 열린목록에 추가

            Target_node = Compare_F(OpenList);      //선택 노드를 열린목록에서 F가 가장 작은값으로 갱신

        }

        TIle_Data temp = Dex_Position;

        while (temp != Start_Position)          //  도착점에서 경로를 따라가다 시작점을 만날때까지 반복
        {
            Reverse_Tile.Add(temp);            //경로를 저장해준다.
            temp = Parent[temp];           //temp 갱신

        }

        Reverse_Tile.Reverse();            //경로 뒤집기

        return Reverse_Tile;              //경로를 반환해준다..

    }

    void Add_Surrounds(Dictionary<TIle_Data, TIle_Data> Parent, List<Node> OpenList, List<Node> ClosedList, Node Target, TIle_Data Dex)
    {                                                       //Target의 주변 Tile을 검사하는 함수
        int x, y;       //Target의 x,y Position
        int f, g, h;    //F, G, H
        int Diagonal;   //대각선 채점 변수(가로세로면 10, 대각선은 14로 채점한다. G값을 채점할때 사용한다.)

        x = (int)Target.tile.Tile_Position.x;          //Target의 위치정보 동기화
        y = (int)Target.tile.Tile_Position.y;

        List<TIle_Data> Arrounds = new List<TIle_Data>();             //주변 Tile들을 넣어줄 List


        for (int i = x - 1; i <= x + 1; i++)                //Target을 포함한 인접한 사각형만큼 반복
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                if (!Check_List(ClosedList, MapData[i, j]) &&     //ClosedList에 들어 있지 않을때,
                    (!(i == x) || !(j == y)) &&                                 //x, y값이 Target의 위치가 아닐때,
                    MapManager.Is_Move_Able_Tile(MapData[i, j].Tile_Sort) && //Tile의 sort는 tile일때,
                    !Check_List(OpenList, MapData[i, j]))             //OpenList에 들어 있지 않을때,
                {
                    Diagonal = ((i != x) && (j != y)) ? 14 : 10;        //Diagonal 채점
                    g = Target.G + Diagonal;                            //해당 Tile의 G = 부모 Tile의 G + 채점된 Diagonal
                    h = Get_H(i, j, Dex);                               //H 채점
                    f = g + h;
                    Node node = new Node { tile = MapData[i, j], F = f, G = g, H = h };
                    OpenList.Add(node);
                    Arrounds.Add(node.tile);
                    Parent.Add(MapData[i, j], Target.tile);

                }
            }

        }



        for (int i = x - 1; i <= x + 1; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                if (!Check_List(ClosedList, MapData[i, j]) &&
                    (!(i == x) || !(j == y)) &&
                    MapData[i, j] == MapData[i, j] &&
                    MapManager.Is_Move_Able_Tile(MapData[i, j].Tile_Sort) //Tile의 sort는 tile일때,

                    )
                {


                    if (Check_List(OpenList, MapData[i, j]))
                    {
                        if (OpenList[Selected_Tile_Num].G < Target.G)
                        {


                            Node NewTarget = OpenList[Selected_Tile_Num];
                            int NewTarget_Value = Selected_Tile_Num;

                            int x_, y_;
                            x_ = (int)NewTarget.tile.Tile_Position.x;
                            y_ = (int)NewTarget.tile.Tile_Position.y;



                            for (int k = x_ - 1; k <= x_; k++)
                            {
                                for (int l = y_ - 1; l <= y_ + 1; l++)
                                {
                                    Diagonal = ((k != x_) && (l != y_)) ? 14 : 10;

                                    if ((!(k == x_) || !(l == y_)) &&
                                        MapManager.Is_Move_Able_Tile(MapData[k, l].Tile_Sort) && //Tile의 sort는 tile일때,
                                        MapData[k, l] != Target.tile)
                                    {
                                        if (Arrounds.Contains(MapData[k, l]) && Check_List(OpenList, MapData[k, l]))
                                        {
                                            Parent.Remove(MapData[k, l]);
                                            Parent.Add(MapData[k, l], NewTarget.tile);

                                            OpenList[Selected_Tile_Num].G = OpenList[NewTarget_Value].G + Diagonal;
                                            OpenList[Selected_Tile_Num].F = OpenList[Selected_Tile_Num].G + OpenList[Selected_Tile_Num].H;


                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }


    void Add_Surrounds_Parent(TIle_Data NewTarget, List<Node> ClosedList)
    {

        int x, y;
        x = (int)NewTarget.Tile_Position.x;
        y = (int)NewTarget.Tile_Position.y;

        for (int i = x - 1; x <= x + 1; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                if (!Check_List(ClosedList, MapData[i, j]) &&
                     (!(i == x) || !(j == y)) &&
                     MapManager.Is_Move_Able_Tile(MapData[i, j].Tile_Sort)) //Tile의 sort는 tile일때,
                {

                }
            }
        }


    }



    int Get_H(int x, int y, TIle_Data dex)
    {
        return (int)Mathf.Abs(dex.Tile_Position.x - x) + (int)Mathf.Abs(dex.Tile_Position.y - y) * 10;

    }

    Node Compare_F(List<Node> OpenList)
    {
        int Compare_Value;
        Compare_Value = OpenList[0].F;
        Selected_Tile_Num = 0;

        for (int i = 0; i <= OpenList.Count - 1; i++)       //나중에 foreach로 바꾸자
        {
            if (OpenList[i].F < Compare_Value)
            {
                Compare_Value = OpenList[i].F;
                Selected_Tile_Num = i;



            }
        }

        return OpenList[Selected_Tile_Num];


    }


    private bool Check_List(List<Node> List, TIle_Data target)
    {
        for (int i = 0; i <= List.Count - 1; i++)
        {
            if (List[i].tile == target)
            {
                Selected_Tile_Num = i;
                return true;

            }

        }

        return false;

    }
}