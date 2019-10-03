using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Size
{
    public int Width;
    public int Height;

    public Room_Size(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }
}

public class MapPattern
{
    private MapManager MapManager;


    public MapPattern(MapManager mapManager)
    {
        this.MapManager = mapManager;
    }

    public eTile[,] Get_Room_Patterns(Room_Size size)
    {
        int Size_num = size.Width * 100 + size.Height;

        eTile[,] value = null;
        eTile W = MapManager.Get_Stage_Data().Wall;
        eTile O = MapManager.Get_Stage_Data().Nomal;
        eTile A = MapManager.Get_Stage_Data().Concept_Tile_1;
        eTile B = MapManager.Get_Stage_Data().Concept_Tile_2;
        eTile N = eTile.NULL;


        switch (Size_num)
        {
            case 606:       //6x6
                {
                    int num = Random.Range(0, 3 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W},
                                    {W,O,O,O,O,W},
                                    {W,O,A,O,O,W},
                                    {W,O,A,A,O,W},
                                    {W,O,O,O,A,W},
                                    {W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 1:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,N,N},
                                    {W,O,A,W,N,N},
                                    {W,O,A,W,W,W},
                                    {W,A,O,O,A,W},
                                    {W,O,O,O,O,W},
                                    {W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 2:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,N,N},
                                    {W,O,A,W,N,N},
                                    {W,O,A,W,W,W},
                                    {W,W,O,O,A,W},
                                    {N,W,W,O,O,W},
                                    {N,N,W,W,W,W}
                                };
                                break;
                            }
                        case 3:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W},
                                    {W,O,A,O,O,W},
                                    {W,O,A,O,O,W},
                                    {W,W,W,O,A,W},
                                    {N,N,W,O,O,W},
                                    {N,N,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 706:       //7x6
                {
                    int num = Random.Range(0, 3 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W},
                                    {W,O,A,O,O,O,W},
                                    {W,O,O,O,O,A,W},
                                    {W,O,O,A,O,O,W},
                                    {W,O,A,O,O,O,W},
                                    {W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 1:
                            {
                                value = new eTile[,]
                                {
                                    {N,N,W,W,W,W,W},
                                    {N,N,W,O,O,O,W},
                                    {W,W,W,O,O,A,W},
                                    {W,O,O,A,O,O,W},
                                    {W,O,A,O,O,O,W},
                                    {W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 2:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,N,N},
                                    {W,O,A,O,W,N,N},
                                    {W,O,O,O,W,N,N},
                                    {W,O,O,A,W,W,W},
                                    {W,O,A,O,O,O,W},
                                    {W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 3:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W},
                                    {W,O,A,O,O,O,W},
                                    {W,W,W,W,O,A,W},
                                    {N,N,N,W,O,O,W},
                                    {N,N,N,W,O,O,W},
                                    {N,N,N,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 806:       //8x6
                {
                    int num = Random.Range(0, 3 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W},
                                    {W,O,O,A,O,A,O,W},
                                    {W,O,O,O,A,O,O,W},
                                    {W,O,A,O,O,A,O,W},
                                    {W,O,O,A,O,O,O,W},
                                    {W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 1:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,N,W,W,W,W},
                                    {W,O,W,N,W,A,O,W},
                                    {W,O,W,W,W,O,O,W},
                                    {W,O,A,O,O,A,O,W},
                                    {W,O,O,A,O,O,O,W},
                                    {W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 2:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W},
                                    {W,O,O,A,O,A,O,W},
                                    {W,O,O,O,A,O,O,W},
                                    {W,O,A,W,W,W,O,W},
                                    {W,O,O,W,N,W,O,W},
                                    {W,W,W,W,N,W,W,W}
                                };
                                break;
                            }
                        case 3:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W},
                                    {W,O,O,A,O,A,O,W},
                                    {W,O,O,O,A,O,O,W},
                                    {W,O,A,W,W,W,W,W},
                                    {W,O,O,W,N,N,N,N},
                                    {W,W,W,W,N,N,N,N}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 906:       //9x6
                {
                    int num = Random.Range(0, 3 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,A,A,O,O,W},
                                    {W,O,A,O,O,A,O,O,W},
                                    {W,O,O,O,O,O,A,O,W},
                                    {W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 1:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,N,N,N},
                                    {W,O,O,O,O,W,N,N,N},
                                    {W,O,O,O,A,W,W,W,W},
                                    {W,O,A,O,O,A,O,O,W},
                                    {W,O,O,O,O,O,A,O,W},
                                    {W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 2:
                            {
                                value = new eTile[,]
                                {
                                    {N,N,W,W,W,W,W,W,W},
                                    {N,N,W,O,O,O,O,O,W},
                                    {W,W,W,O,A,A,O,O,W},
                                    {W,O,A,O,O,A,W,W,W},
                                    {W,O,O,O,O,O,W,N,N},
                                    {W,W,W,W,W,W,W,N,N}
                                };
                                break;
                            }
                        case 3:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,N,N},
                                    {W,O,O,O,O,O,W,N,N},
                                    {W,O,O,O,A,A,W,W,W},
                                    {W,W,W,O,O,A,O,O,W},
                                    {N,N,W,O,O,O,A,O,W},
                                    {N,N,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1006:       //10x6
                {
                    int num = Random.Range(0, 3 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,A,O,O,O,O,W},
                                    {W,O,O,O,A,A,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,A,O,W},
                                    {W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 1:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,A,O,O,O,O,W},
                                    {W,O,O,O,A,A,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,W,W,W,W,W,W,W,W},
                                    {W,W,W,N,N,N,N,N,N,N}
                                };
                                break;
                            }
                        case 2:
                            {
                                value = new eTile[,]
                                {
                                    {N,N,N,N,N,N,N,W,W,W},
                                    {W,W,W,W,W,W,W,W,O,W},
                                    {W,O,O,O,A,A,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,A,O,W},
                                    {W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 3:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,N,W,W,W,W,W},
                                    {W,O,O,W,N,W,O,O,O,W},
                                    {W,O,O,W,W,W,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,A,O,W},
                                    {W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1106:       //11x6
                {
                    int num = Random.Range(0, 3 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,A,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,A,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 1:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,A,O,O,O,O,O,W,W,W},
                                    {W,O,O,O,O,O,O,O,W,N,N},
                                    {W,O,O,O,O,O,O,A,W,N,N},
                                    {W,W,W,W,W,W,W,W,W,N,N}
                                };
                                break;
                            }
                        case 2:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,A,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,O,O,O,O,O,O,W},
                                    {N,N,N,W,O,O,O,A,O,O,W},
                                    {N,N,N,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 3:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,N,W,W,W},
                                    {W,O,O,O,O,O,W,W,W,O,W},
                                    {W,O,A,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,W,W,W,O,A,O,O,W},
                                    {W,W,W,W,N,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1206:       //12x6
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,A,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,A,O,O,O,W},
                                    {W,O,A,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1306:       //13x6
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,A,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,A,O,O,O,O,O,O,A,O,O,W},
                                    {W,O,O,A,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1406:       //14x6
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,A,O,O,O,O,O,W},
                                    {W,O,O,A,O,O,O,O,O,O,A,O,O,W},
                                    {W,O,O,O,O,O,O,O,A,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 607:       //6x7
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W},
                                    {W,O,O,O,O,W},
                                    {W,O,A,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,A,O,O,A,W},
                                    {W,O,O,O,A,W},
                                    {W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 707:       //7x7
                {
                    int num = Random.Range(0, 1 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,A,O,W},
                                    {W,O,A,O,O,O,W},
                                    {W,O,A,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 1:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,N,N},
                                    {W,O,O,O,W,N,N},
                                    {W,O,O,O,W,W,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,A,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 807:       //8x7
                {
                    int num = Random.Range(0, 1 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,A,O,W},
                                    {W,O,A,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 1:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W},
                                    {W,A,A,O,O,O,O,W},
                                    {W,O,A,O,O,O,O,W},
                                    {W,O,W,W,W,O,O,W},
                                    {W,O,W,N,W,O,O,W},
                                    {W,O,W,N,W,O,O,W},
                                    {W,W,W,N,W,W,W,W}
                                };
                                break;
                            }

                    }
                    break;
                }
            case 907:       //9x7
                {
                    int num = Random.Range(0, 1 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,A,O,O,A,O,O,W},
                                    {W,O,A,O,O,O,O,O,W},
                                    {W,O,O,A,A,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 1:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W},
                                    {W,O,A,O,O,O,O,O,W},
                                    {W,O,O,O,A,O,A,O,W},
                                    {W,W,W,W,W,W,O,A,W},
                                    {N,N,N,N,N,W,O,O,W},
                                    {N,N,N,N,N,W,O,O,W},
                                    {N,N,N,N,N,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1007:       //10x7
                {
                    int num = Random.Range(0, 1 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,A,O,O,O,O,O,W},
                                    {W,O,O,A,O,O,O,O,O,W},
                                    {W,O,A,O,O,O,O,O,O,W},
                                    {W,O,A,O,O,O,A,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 1:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,W,W,W,W,O,O,W},
                                    {W,A,O,W,N,N,W,O,A,W},
                                    {W,A,O,W,W,W,W,O,O,W},
                                    {W,O,O,A,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1107:       //11x7
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,A,O,O,W},
                                    {W,W,W,W,W,O,O,O,O,O,W},
                                    {N,N,N,N,W,O,O,O,O,O,W},
                                    {W,W,W,W,W,O,O,A,O,O,W},
                                    {W,O,O,O,O,O,A,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1207:       //12x7
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,A,A,O,O,O,O,O,W},
                                    {W,O,O,O,A,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,A,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1307:       //13x7
                {
                    int num = Random.Range(0, 1 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,A,O,O,O,O,O,O,O,A,O,W},
                                    {W,O,O,O,O,O,A,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,A,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 1:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,N,W,W,W,N,W,W,W,W,W},
                                    {W,O,W,N,W,O,W,N,W,O,O,O,W},
                                    {W,O,W,N,W,O,W,N,W,O,A,O,W},
                                    {W,O,W,W,W,O,W,W,W,O,A,O,W},
                                    {W,O,O,O,O,O,A,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,A,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1407:       //14x7
                {
                    int num = Random.Range(0, 1 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,A,O,O,O,O,W},
                                    {W,O,O,A,A,O,O,O,A,A,O,O,O,W},
                                    {W,O,O,A,A,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 1:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,O,A,A,W},
                                    {N,N,N,N,N,N,N,N,N,W,O,A,A,W},
                                    {N,N,N,N,N,N,N,N,N,W,O,O,A,W},
                                    {N,N,N,N,N,N,N,N,N,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 608:       //6x8
                {
                    int num = Random.Range(0, 1 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W},
                                    {W,O,A,O,O,W},
                                    {W,A,O,O,O,W},
                                    {W,O,O,A,O,W},
                                    {W,O,O,A,O,W},
                                    {W,O,A,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 1:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W},
                                    {W,O,O,O,O,W},
                                    {W,O,A,A,O,W},
                                    {W,A,O,O,O,W},
                                    {W,O,W,W,W,W},
                                    {W,O,W,N,N,N},
                                    {W,O,W,N,N,N},
                                    {W,W,W,N,N,N}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 708:       //7x8
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,W},
                                    {W,A,O,O,O,O,W},
                                    {W,O,O,A,O,O,W},
                                    {W,O,O,A,O,O,W},
                                    {W,A,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 808:       //8x8
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,A,O,O,O,W},
                                    {W,O,O,O,O,O,A,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,A,A,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 908:       //9x8
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,A,O,W},
                                    {W,O,O,O,O,O,A,O,W},
                                    {W,O,O,A,O,O,O,O,W},
                                    {W,O,A,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1008:       //10x8
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,A,O,O,W},
                                    {W,O,A,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,A,A,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1108:       //11x8
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,A,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,A,A,O,O,O,O,O,W},
                                    {W,O,O,A,A,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1208:       //12x8
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,A,O,O,O,O,O,A,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,A,O,O,O,A,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,A,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1308:       //13x8
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1408:       //14x8
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }

            case 609:       //6x9
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 709:       //7x9
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 809:       //8x9
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 909:       //9x9
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1009:       //10x9
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1109:       //11x9
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1209:       //12x9
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1309:       //13x9
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1409:       //14x9
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 610:       //6x10
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 710:       //7x10
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 810:       //8x10
                {
                    int num = Random.Range(0, 3 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 1:
                            {
                                value = new eTile[,]
                                {
                                    {N,N,W,W,W,W,W,W},
                                    {N,N,W,O,O,O,O,W},
                                    {W,W,W,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,W,W,W},
                                    {W,O,O,O,O,W,N,N},
                                    {W,O,O,O,O,W,N,N},
                                    {W,W,W,W,W,W,N,N}
                                };
                                break;
                            }
                        case 2:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,W,W,W,W,O,W},
                                    {W,O,W,N,N,W,O,W},
                                    {W,O,W,N,N,W,O,W},
                                    {W,O,W,W,W,W,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 3:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,N,N,N,N},
                                    {W,O,O,W,N,N,N,N},
                                    {W,O,O,W,N,N,N,N},
                                    {W,O,O,W,N,N,N,N},
                                    {W,O,O,W,N,N,N,N},
                                    {W,O,O,W,N,N,N,N},
                                    {W,O,O,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 910:       //9x10
                {
                    int num = Random.Range(0, 3 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 1:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,O,O,W},
                                    {N,N,N,N,N,W,O,O,W},
                                    {N,N,N,N,N,W,O,O,W},
                                    {N,N,N,N,N,W,O,O,W},
                                    {N,N,N,N,N,W,W,W,W}
                                };
                                break;
                            }
                        case 2:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,W,W,W,W},
                                    {W,O,O,O,O,W,N,N,N},
                                    {W,O,O,O,O,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,W,W,O,O,O,O,O,W},
                                    {N,N,W,O,O,O,O,O,W},
                                    {N,N,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 3:
                            {
                                value = new eTile[,]
                                {
                                    {N,N,N,W,W,W,W,W,W},
                                    {N,N,N,W,O,O,O,O,W},
                                    {W,W,W,W,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1010:       //10x10
                {
                    int num = Random.Range(0, 3 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 1:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,W,W,W,W,W,W,W},
                                    {W,O,O,W,N,N,N,N,N,N},
                                    {W,O,O,W,N,N,N,N,N,N},
                                    {W,O,O,W,N,N,N,N,N,N},
                                    {W,O,O,W,N,N,N,N,N,N},
                                    {W,O,O,W,N,N,N,N,N,N},
                                    {W,O,O,W,N,N,N,N,N,N},
                                    {W,W,W,W,N,N,N,N,N,N}
                                };
                                break;
                            }
                        case 2:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,W,W,W,W,O,O,W},
                                    {W,O,O,W,N,N,W,O,O,W},
                                    {W,O,O,W,N,N,W,O,O,W},
                                    {W,O,O,W,W,W,W,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 3:
                            {
                                value = new eTile[,]
                                {
                                    {N,N,N,N,N,N,W,W,W,W},
                                    {N,N,N,N,N,N,W,O,O,W},
                                    {W,W,W,W,W,W,W,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,W,W,W,O,O,O,O,W},
                                    {W,O,W,N,W,O,O,O,O,W},
                                    {W,O,W,N,W,O,O,O,O,W},
                                    {W,W,W,N,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1110:       //11x10
                {
                    int num = Random.Range(0, 3 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 1:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,N,N},
                                    {W,O,O,O,O,O,O,O,W,N,N},
                                    {W,O,O,O,O,O,O,O,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 2:
                            {
                                value = new eTile[,]
                                {
                                    {N,N,W,W,W,W,W,W,W,N,N},
                                    {N,N,W,O,O,O,O,O,W,N,N},
                                    {W,W,W,O,O,O,O,O,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,O,O,O,O,O,W,W,W},
                                    {N,N,W,O,O,O,O,O,W,N,N},
                                    {N,N,W,W,W,W,W,W,W,N,N}
                                };
                                break;
                            }
                        case 3:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,O,O,O,O,W},
                                    {N,N,N,N,N,W,O,O,O,O,W},
                                    {N,N,N,N,N,W,O,O,O,O,W},
                                    {N,N,N,N,N,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1210:       //12x10
                {
                    int num = Random.Range(0, 3 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 1:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,W,N,N,N,N,N,N,N,N},
                                    {W,O,O,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 2:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,W,N,N,N,N},
                                    {W,O,O,O,O,O,O,W,N,N,N,N},
                                    {W,O,O,O,O,O,O,W,N,N,N,N},
                                    {W,O,O,O,O,O,O,W,N,N,N,N},
                                    {W,O,O,O,O,O,O,W,N,N,N,N},
                                    {W,W,W,W,W,W,W,W,N,N,N,N}
                                };
                                break;
                            }
                        case 3:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,W,W,W,W,W,W,W,O,O,W},
                                    {W,O,W,N,N,N,N,N,W,O,O,W},
                                    {W,O,W,N,W,W,W,N,W,O,O,W},
                                    {W,O,W,W,W,O,W,W,W,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1310:       //13x10
                {
                    int num = Random.Range(0, 3 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 1:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,W,W,W,O,O,O,O,W},
                                    {W,O,O,O,O,W,N,W,O,O,O,O,W},
                                    {W,O,O,O,O,W,W,W,W,W,O,O,W},
                                    {W,O,O,O,O,O,O,W,N,W,O,O,W},
                                    {W,O,O,O,O,O,O,W,W,W,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 2:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,O,O,O,O,O,O,O,W},
                                    {N,N,N,N,W,O,O,O,O,O,O,O,W},
                                    {N,N,N,N,W,O,O,O,O,O,O,O,W},
                                    {N,N,N,N,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 3:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,W,W,W,W,W,O,O,O,W},
                                    {W,O,O,O,W,N,N,N,W,O,O,O,W},
                                    {W,O,O,O,W,N,N,N,W,O,O,O,W},
                                    {W,O,O,O,W,W,W,W,W,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1410:       //14x10
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 611:       //6x11
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 711:       //7x11
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 811:       //8x11
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 911:       //9x11
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1011:       //10x11
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1111:       //11x11
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1211:       //12x11
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1311:       //13x11
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1411:       //14x11
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 612:       //6x12
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 712:       //7x12
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 812:       //8x12
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 912:       //9x12
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }

            case 1012:       //10x12
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1112:       //11x12
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1212:       //12x12
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1312:       //13x12
                {
                    int num = Random.Range(0, 2 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 1:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,W,W,W,W,W,W,W,O,O,W},
                                    {W,O,O,W,N,N,N,N,N,W,O,O,W},
                                    {W,O,O,W,W,W,W,W,W,W,O,O,W},
                                    {W,O,O,W,W,O,O,O,W,W,O,O,W},
                                    {W,O,O,W,W,O,O,O,W,W,O,O,W},
                                    {W,O,O,W,W,O,O,O,W,W,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 2:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,W,W,W,W,W,O,O,O,W},
                                    {W,O,O,O,W,N,N,N,W,O,O,O,W},
                                    {W,O,O,O,W,N,N,N,W,O,O,O,W},
                                    {W,O,O,O,W,N,N,N,W,O,O,O,W},
                                    {W,O,O,O,W,N,N,N,W,O,O,O,W},
                                    {W,O,O,O,W,W,W,W,W,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }

                    }
                    break;
                }
            case 1412:       //14x12
                {
                    int num = Random.Range(0, 1 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 1:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,W,W,W,W,W,W,O,O,O,W},
                                    {W,O,O,O,W,N,N,N,N,W,O,O,O,W},
                                    {W,O,O,O,W,N,N,N,N,W,O,O,O,W},
                                    {W,O,O,O,W,W,W,W,W,W,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 613:       //6x13
                {
                    int num = Random.Range(0, 2 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 1:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,W,W,W,W},
                                    {W,O,W,N,N,N},
                                    {W,O,W,N,N,N},
                                    {W,O,W,N,N,N},
                                    {W,W,W,N,N,N}
                                };
                                break;
                            }
                        case 2:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,N,N,N},
                                    {W,O,W,N,N,N},
                                    {W,O,W,N,N,N},
                                    {W,O,W,W,W,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,W,W,W,W},
                                    {W,O,W,N,N,N},
                                    {W,O,W,N,N,N},
                                    {W,O,W,N,N,N},
                                    {W,W,W,N,N,N}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 713:       //7x13
                {
                    int num = Random.Range(0, 1 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 1:
                            {
                                value = new eTile[,]
                                {
                                    {N,N,W,W,W,W,W},
                                    {N,N,W,O,O,O,W},
                                    {N,N,W,O,O,O,W},
                                    {N,N,W,O,O,O,W},
                                    {W,W,W,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,W,W,O,O,O,W},
                                    {N,N,W,O,O,O,W},
                                    {N,N,W,O,O,O,W},
                                    {N,N,W,O,O,O,W},
                                    {N,N,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 813:       //8x13
                {
                    int num = Random.Range(0, 2 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 1:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,N,N,N,N},
                                    {W,O,O,W,N,N,N,N},
                                    {W,O,O,W,N,N,N,N},
                                    {W,O,O,W,N,N,N,N},
                                    {W,O,O,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,W,W,W,W,W},
                                    {W,O,O,W,N,N,N,N},
                                    {W,O,O,W,N,N,N,N},
                                    {W,O,O,W,N,N,N,N},
                                    {W,W,W,W,N,N,N,N}
                                };
                                break;
                            }
                        case 2:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,W,W,W},
                                    {W,O,O,O,O,W,N,N},
                                    {W,O,O,O,O,W,N,N},
                                    {W,O,O,O,O,W,W,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 913:       //9x13
                {
                    int num = Random.Range(0, 2 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 1:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,W,W,W,O,O,W},
                                    {W,O,O,W,N,W,O,O,W},
                                    {W,O,O,W,N,W,O,O,W},
                                    {W,O,O,W,W,W,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 2:
                            {
                                value = new eTile[,]
                                {
                                    {N,N,N,W,W,W,W,W,W},
                                    {N,N,N,W,O,O,O,O,W},
                                    {N,N,N,W,O,O,O,O,W},
                                    {N,N,N,W,O,O,O,O,W},
                                    {W,W,W,W,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }

            case 1013:       //10x13
                {
                    int num = Random.Range(0, 3 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 1:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,N,N,N},
                                    {W,O,O,O,O,O,W,N,N,N},
                                    {W,O,O,O,O,O,W,N,N,N},
                                    {W,O,O,O,O,O,W,N,N,N},
                                    {W,O,O,O,O,O,W,W,W,W},
                                    {W,O,O,O,O,O,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,O,O,O,O,O,W},
                                    {W,W,W,W,O,O,O,O,O,W},
                                    {N,N,N,W,O,O,O,O,O,W},
                                    {N,N,N,W,O,O,O,O,O,W},
                                    {N,N,N,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                        case 2:
                            {
                                value = new eTile[,]
                                {
                                    {N,N,W,W,W,W,W,W,W,W},
                                    {N,N,W,O,O,O,O,O,O,W},
                                    {W,W,W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W,W,W},
                                    {W,O,O,O,O,O,O,W,N,N},
                                    {W,W,W,W,W,W,W,W,N,N}
                                };
                                break;
                            }
                        case 3:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,N,N,W,W,W,W},
                                    {W,O,O,W,N,N,W,O,O,W},
                                    {W,O,O,W,N,N,W,O,O,W},
                                    {W,O,O,W,W,W,W,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1113:       //11x13
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1213:       //12x13
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1313:       //13x13
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1413:       //14x13
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 614:       //6x14
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,O,O,O,O,W},
                                    {W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 714:       //7x14
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 814:       //8x14
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 914:       //9x14
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }

            case 1014:       //10x14
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1114:       //11x14
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1214:       //12x14
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1314:       //13x14
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }
            case 1414:       //14x14
                {
                    int num = Random.Range(0, 0 + 1);
                    switch (num)
                    {
                        case 0:
                            {
                                value = new eTile[,]
                                {
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,O,O,O,O,O,O,O,O,O,O,O,O,W},
                                    {W,W,W,W,W,W,W,W,W,W,W,W,W,W}
                                };
                                break;
                            }
                    }
                    break;
                }





        }

        return value;
    }







}
