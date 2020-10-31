# NCC China

> .NET Core 中文社区。The .NET Core Community(NCC) of China.

[![Server API CI](https://github.com/tatwd/ncc-china/workflows/Server%20API%20CI/badge.svg)](https://github.com/tatwd/ncc-china/actions?query=workflow:%22Server+API+CI%22)

## Startup

With docker:

```bash
make
```

If no docker, you must config a **MySQL** and **MongoDB** environments firstly.

Run server api:

```bash
# run services
./scripts/run_identity.sh
./scripts/run_postsys.sh
./scripts/run_postsys_comment.sh

# run api gateway
./scripts/run_api_gateway.sh
```
Run web client app:

```bash
cd src/client/nuxt-web
yarn
yarn dev
```

## 贡献

你可以通过 Issue 和 Pull Request 的方式参与贡献。

如果你想要为这个仓库贡献你的代码，你需要遵循以下步骤：

1. 首先，请 Fork 这个仓库到你的账户上；
2. 然后，将 Fork 后的仓库克隆到本地；
3. 本地添加一个 `remote` 账户并指向源仓库，以作为更新账户来同步源仓库的代码；

   ``` bash
   # 添加上游账户 up 并指向源仓库
   git remote add up https://github.com/tatwd/ncc-china.git

   # 同步源仓库 master 分支代码
   git pull up master
   ```

4. 创建并切换到开发分支上，编写你的代码；
5. 完成并通过单元测试，然后提交更改；
6. 发起一个 Pull Request 以完成你的贡献。

注意，你的提交必须使用英文，每次提交代码的信息的一般包含 **header**、**body** 和 **footer**，它们之间包含一个空行，其中 **header** 包含了 **type**、**scope** 和 **subject** 三部分：

```txt
<type>(<scope>): <subject>
<BLANK LINE>
<body>
<BLANK LINE>
<footer>
```

**type** 和 **subject** 是必须的，**scope**、**body**、**footer** 是可选的。

**type** 的有以下值:

- feat：添加了新的特性；
- fix: 对代码进行 bug 的修复；
- docs：只对相关文档做了修改，如 README 等；
- style：对代码做了格式化，如空格、分号等；
- refactor： 重构代码，既没有 feat 也没有 fix；
- test：添加测试、重构测试；
- perf: 对代码进行了性能的提升；
- chore：改变构建流程、或者增加依赖库、工具等；
- revert：回滚到上一个版本；

**scope**：模块名，即修改的主要模块，单个词。

**subject**：对变动的简要描述，主要做了什么，与前面的冒号有一个空格，首字母小写，字数控制在 50 字以内，结尾不加标点。

**body**：主要解释为什么要做这些改动，单行不超过 72 个字，内容多行时以`-`分隔。

**footer**：主要提供相关文章和其它资源的链接和关键字，可以包含 issue 或 PR 编号。

例子 1：

```txt
docs(changelog): update changelog to beta.5
```

例子 2：

```txt
fix(core): minor typos in code

- see the issue for details on the typos fixed
- see the issue for details on the typos fixed

fixes issue #12
```

更多例子请参看仓库的[提交历史](https://github.com/tatwd/ncc-china/commits/master)。

感谢你的参与！

## 许可证

[MIT](https://opensource.org/licenses/MIT)
