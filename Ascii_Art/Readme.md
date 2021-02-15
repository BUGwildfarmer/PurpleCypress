## python 实现字符动画视频

> tools:
> pillow,numpy
> ffmpeg


使用：

* 视频流解析成帧图片：`ffmpeg -i 视频文路径 -r 30 -qscale:v 2 输出文件路径(eg.out/%04d.jpg)`
* 图片序列合成视频：`ffmpeg -i 输入文件夹路径(%04d.jpg) -c:v libx264 -vf fps=30 -pix_fmt yuv420p 输出文件路径(eg.out.mp4)`
* 图片转化为字符图片：在 `ascii_draw.py` 中，对 `origin` 的图片进行批转换，存储至 `out` 文件夹中，过程主要包括：`采样` `量化` `编码` `绘制` `存储`