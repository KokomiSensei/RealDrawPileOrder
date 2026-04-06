# 真实抽牌堆顺序

[English version](./READEME.md) | [简体中文版本](./README.zh-CN.md)

## 说明

这是一个适用于《Slay the Spire 2》的模组，可以让玩家在打开抽牌堆界面时查看抽牌堆中卡牌的顺序，便于策略制定与决策。

本模组不要求多人游戏中的其他玩家也安装（通过在模组清单中将 `affects_gameplay` 设为 `false` 实现仅展示，不改变规则）。

## 兼容性

此模组在游戏 v0.99.1 版本上开发与测试，未来版本可能不兼容。请在模组发布页查看更新与兼容性信息。

## 安装与使用

详情请参见模组发布页： [Nexus Mods](https://www.nexusmods.com/slaythespire2/mods/414)

## 从源码构建

1. 安装并下载 Slay the Spire 2。
2. 安装 .NET 9.0 SDK。
3. 克隆本仓库。
4. 进入项目目录（`cd` 到项目文件夹）。
5. 运行以下命令进行构建：

```bash
dotnet build -c Release   # 发布版
dotnet build -c Debug     # 调试版
```

6. 编译后产物会被复制到 Slay the Spire 2 安装目录下的 `mods` 文件夹（取决于项目的构建脚本配置）。
7. 启动游戏并验证模组是否生效。
