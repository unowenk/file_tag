# file_tag
尝试做一个，通过标签管理文件分类存储的工具
文件只有单份，以移入或复制入方式，不想考虑只放个链接文件进去
现阶段计划是，做win平台，一个命令程序，注册到系统右键，通过弹窗方式，希望我之后做到这步能顺利找到对文件批量操作的方式
功能：建立存储分区（详细配置要到注册表修改了）、通过标签名（通过'#'连接）建立文件夹、管理各文件夹内链接到另一文件夹的快捷键、管理现有标签
目录结构：
存储分区\
    tag_file_config.config # 标志这是存储分区，暂时没考虑到任何需要配置的东西
    tag_file_config.json # 记录标签与hash的关系
    一级标签\
        <所有标签的文件夹，按标签元素进入>
        # 设计上的问题是，只能往详细标签走，不能返回上级目录，因为有过多上级，而且命名麻烦。
        # 初步解决预想还是通过弹窗转跳到指定标签
    未完成标记文件夹\(不做了，太复杂)
        <未完成标记文件> # 未完成标记，是个超级标签，有这个标签的文件。初步移入存储分区的文件
        未完成标记.db # 标签缓存
    存储\
        <hash(<标签[#标签[#标签[...]]]>)>\
        # 多重标签元素，对应一个文件夹，为了命名长度问题必须hash，（而且要截到有限长度）。浏览各标签从《一级标签\》进入
            _tag.txt # 单纯的管理说明文件，说明这文件夹有哪些标签，只读。#链接
            <存储的文件> # 理论上可以通过手动移动文件，达到修改标签的目的
存粹的基础标签功能：标签查询、标签分组
管理标签功能：增删改，标签合并，管理链接（一级标签，与各级的进入下一级）、标签统计
管理文件标签功能：增删改，文件的移动、按标签（链接）筛选检索文件


https://dotnet.microsoft.com/download/dotnet-core/thank-you/runtime-desktop-3.1.9-windows-x64-installer