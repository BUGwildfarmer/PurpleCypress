## python 实现字符动画视频

**环境：**

> 操作系统为 windows
> 需要安装 [ffmpeg](https://ffmpeg.en.softonic.com/) ，并加入环境变量
> python 需要安装的库有：
> ffmpy3,pillow,numpy


**使用：**

1. 将需要转化的视频与 `ascii_draw.py` 放在同一文件夹下
2. 在当前文件打开 cmd ，输入以下命令：`python ascii_draw.py xxx.mp4（视频文件名）`



**代码简介：**

1.函数 `video_to_frames(video_file)` 功能：

* 创建存储视频原序列帧文件夹
* 利用 ffmpeg 进行视频分帧，其 cmd 命令格式为`ffmpeg -i 视频文路径 -r 30 -qscale:v 2 输出文件路径(eg.out/%04d.jpg)`

2.函数 `ascii_art` 功能

将输入的单个图片文件进行 `采样` `量化` `编码` `绘制` `存储` 处理

3.函数 `pics_to_ascii` 功能：

* 创建存储字符帧序列文件夹
* 调用 `ascii_art` 函数批处理视频原序列帧

4.函数 `asciipic_to_video` 功能

利用 ffmpeg 进行合成序列帧为视频，其 cmd 命令格式为`ffmpeg -i 输入文件夹路径(%04d.jpg) -c:v libx264 -vf fps=30 -pix_fmt yuv420p 输出文件路径(eg.out.mp4)`