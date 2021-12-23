## 1. 整体框架

​		创建panel，使用osa插件来实现多排行榜节点的优化问题

## 2. 项目结构

* scene
  * MainScene
* Scripts
  * SimpleJson               //解析json文件
* Resources
  * Rank_icon				             //段位图标
  * image                       //界面ui
* Prefabs                            //存储prefab
* OSA                                  //osa插件目录

## 3.代码逻辑分层
| 文件夹     | 主要职责                 |
| ---------- | ------------------------ |
| Resources  | 存放资源                 |
| Scripts    | 存放脚本文件             |
| Prefabs    | 存放预制体资源           |
| data       | 存放本地存放的json数据等 |
| Scene      | 存放场景文件             |
| SimpleJSON | 存放解析json的工具       |
| OSA					| osa插件目录 |

## 4. 流程图

![](https://github.com/89trillion-wangjian/RankGame/blob/master/squence.png)
