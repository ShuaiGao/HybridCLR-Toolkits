# HybridCLR-Toolkits

[![license](http://img.shields.io/badge/license-MIT-blue.svg)](https://opensource.org/licenses/MIT)[![openupm](https://img.shields.io/npm/v/com.focus-creative-games.huatuo?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.focus-creative-games.huatuo/)

HybridCLR-Toolkits 是一个 unity 工具包的源码仓库。

HybridCLR-Toolkits 是 unity 中 huatuo 使用工具的集合，用来模拟手工安装 huatuo 的操作，实现自动化的安装、卸载操作。

## 废弃警告

该仓库为原 huatuo_upm 的改名版，目前支持 HybridCLR(wolong)的自动安装功能，且使用设置环境变量的方式工作，与 HybridCLR_trial 项目工作方式相同。该工具计划支持 HybridCLR_trial 项目中的所有 Editor 功能，以方便在 unity 中集成和使用 HybridCLR。

但当前该项目已停止维护，计划后面交给【海浪】维护，感兴趣的朋友可以从当前仓库 fork 创建自己的版本，集成更多的功能，繁荣 HybridCLR 社区。

### 使用方式

当前项目没有发布 upm 包，但可以从自己本地加载工具。即在 unity 的 package manager 中选择 add package from disk，然后选择本项目下的 `Assets/HybridCLR/package.json` 即可使用

> 下面的内容是原 huatuo_upm，暂做保留

## 安装

支持最小 unity 版本 2020.3

多种安装方法如下，或参照海浪哥哥的[手把手教你使用 Huatuo 部署插件](https://zhuanlan.zhihu.com/p/513834841)

### 方法 1： 使用 OpenUPM 的 Unity 依赖文件

1. 打开 unity 工程的根目录

2. 打开编辑文件 Packages\mainfest.json

3. 在 scopedRegistries 数据中添加注册信息，配置 unity 包搜索 URL。示例如下

    ```json
    {
        "dependencies": {
            ...
        },
        "scopedRegistries": [
            {
                "name": "package.openupm.cn",
                "url": "https://package.openupm.cn",
                "scopes": [
                    "com.focus-creative-games.huatuo"
                ]
            }
        ]
    }
    ```

4. 打开 Unity 后会弹出 Edit->Project Settings->Package Manager 界面，可以看到 Scoped Registries 中已经自动填充了信息。切换到 Window->Package Manager->Packages: My Registries 中将看到名为`huatuo Tookit for Unity`的包，其它操作在 Package Manager 中进行即可。

### 方法 2：使用 openupm-cn 命令行

关于 OpenUPM CLI 的命令行工具可以参照 [OpenUPM-CLI 快速入门文档](https://openupm.cn/zh/docs/getting-started.html#安装openupm-cli)

1. 安装命令行工具
2. 命令行中跳转到在对应 Unity 工程目录（包含 Assets 或 Packages 的目录）
3. 输入命令安装`openupm-cn add com.focus-creative-games.huatuo`
4. 后续操作参照方法 1-第 4 步。

### 方法 3： 使用 Unity Package Manager 安装

1. 在 Unity 中，点击 Edit->Project Settings，选择 Package Manager
2. 在 Scoped Registries 中添加下面信息
    - Name: package.openupm.cn
    - URL: https://package.openupm.cn
    - Scope(s): com.focus-creative-games.huatuo
3. 点击 Save
4. 后续操作参照方法 1-第 4 步。

## 工作原理

### 安装和卸载

安装和卸载完全模拟手工操作，都是目录的替换。

安装流程如下：

1. 下载源代码 zip。下载并将压缩包存储在缓存目录（缓存目录可配置），**如遇下载失败可手动下载并将文件置于缓存目录**。
2. 备份 Libil2cpp。在 il2cpp 目录备份原始 Libil2cpp 文件夹，**此处注意在安装前应先恢复之前的本地改动**。
3. 解压缩源码 zip。
4. 版本信息写入文件。版本信息写入到对应 Unity Editor 路径下，例：...\\2020.3.33f1c2\Editor\\.huatuo

卸载流程如下：

1. 检查是否存在原始文件夹备份。备份文件夹名示例 例：\...\\2020.3.33f1c2\Editor\Data\il2cpp\libil2cpp_original_unity
2. 移除 libil2cpp，将 libil2cpp_original_unity 重命名为 libil2cpp
