## python 实现字符动画视频

**环境：**

> 操作系统为 windows
> 需要安装 [ffmpeg](https://ffmpeg.en.softonic.com/) ，并加入环境变量
> python 需要安装的库有：
> ffmpy3,pillow,numpy


**使用示例**

`python pic_str.py -i a.jpg b.png c.jpg -v aa.mp4 bb.wmv`
参数 `-i` `--image` 将图片转换为字符图片，结果存放在 `image_reuslt` 文件夹下 
参数 `-v` `--video` 将视频转换为字符视频，结果存放在 `video_result` 文件夹下

注意：程序运行时间与图片大小或视频长度正相关，代码中视频合成为粗合成，需通过格式工厂等软件进行进一步压缩调整方可顺利播放



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