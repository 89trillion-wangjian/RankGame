## 1. 整体框架

controller中解析数据，成功后打开panel，通过OSA创建scroll view，优化列表节点问题，每个item有单独的控制脚本，点击弹出全局toast提示。


## 2. 项目结构

* Scene
  * MainScene
* Scripts                  #脚本目录
* Resources
  * Rank_icon				          #段位图标
  * Image                  #界面ui
* Prefabs                  #存储prefab
* OSA                      #osa插件目录
* Data                     #json数据
* Res                      #静态资源

## 3.代码逻辑分层
|文件夹        |主要职责                  |
|-----------   |----------              |
|Controller     |处理逻辑，ui监听                |
|Entity       |静态类，枚举等              |
|Model       |存放玩家数据，设置委托            |
|Utils          |事件传递脚本，工具  |
|View         |委托事件绑定，处理ui显示，toast提示等             |
| SimpleJSON | 存放解析json的工具       |
| OSA					| osa插件目录|

## 4. 流程图

![](https://github.com/89trillion-wangjian/RankGame/blob/master/seq.png)
