# Anti_involutionFighter(反卷斗士)
Unity版本：2020.3.5f1c1


Art里放美术资源

Src包括Client客户端和Server服务端

其余的正在搭

Client目录
ASSETS
├───Editor								编辑器相关脚本
├───GameAssets					游戏资源
│   └───SceneOrFunctions		功能划分
│      ├───Prefabs					预制体、shaders以及其他
│      ├───Shaders
│      └───Sprites
├───Gizmos							Scene Debug相关脚本
├───Plugins								三方插件等
│   └───DOTween
│      ├───Editor
│      │   └───Imgs
│      └───Modules
├───References						引用暂时放的protobuff
├───Resources							资源文件夹
├───Scenes								场景文件夹
├───Scripts								业务脚本文件夹
│   ├───GameUi                           按功能划分
│   │   ├───BattleUi
│   │   │   └───UI_ItemScripts
│   │   ├───Framework         	    前端UI框架
│   │   ├───GamePlay
│   │   │   └───Cards
│   │   └───SuperListUi
│   │       ├───Module                    MVC结构
│   │       └───View
│   ├───Log									日志脚本
│   ├───Network							网络脚本
│   ├───Scene								场景管理脚本
│   └───Utilities							工具类
└───StreamingAssets					流式资源（相对于Resources不压缩）

