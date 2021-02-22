from ffmpy3 import FFmpeg
from PIL import Image, ImageDraw, ImageFont
import numpy as np
import os
import sys
import shutil

sample_rate = 0.1

# ffmpeg -i 视频文路径 -r 30 -qscale:v 2 输出文件路径(eg.out/%04d.jpg)


def video_to_frames(viedo_file):
    # 创建存储视频原始帧序列文件夹
    os.mkdir("test_origin")
    # 执行ffmpeg命令，30对应帧数
    ff = FFmpeg(inputs={viedo_file: None}, outputs={
                'test_origin/%04d.jpg': ['-r', '30', '-qscale:v', '2']})
    ff.run()


def ascii_art(file):
    im = Image.open(file)

    # Compute letter aspect ratio
    font = ImageFont.load_default()
    aspect_ratio = font.getsize("x")[0] / font.getsize("x")[1]
    new_im_size = np.array(
        [im.size[0] * sample_rate, im.size[1] * sample_rate * aspect_ratio]
    ).astype(int)

    # Downsample the image
    im = im.resize(new_im_size)

    # Keep a copy of image for color sampling
    im_color = np.array(im)

    # Convert to gray scale image
    im = im.convert("L")

    # Convert to numpy array for image manipulation
    im = np.array(im)

    # Defines all the symbols in ascending order that will form the final ascii
    symbols = np.array(list(" .,-vYM@"))

    # Normalize minimum and maximum to [0, max_symbol_index)
    im = (im - im.min()) / (im.max() - im.min()) * \
        (symbols.size - 1) if im.min() != im.max() else im

    # Generate the ascii art
    ascii = symbols[im.astype(int)]
    # lines = "\n".join("".join(r) for r in ascii)
    # f = open("zizi.txt", "w")
    # print(lines,file = f)
    # f.close()

    # Create an output image for drawing ascii text
    letter_size = font.getsize("x")
    im_out_size = new_im_size * letter_size
    bg_color = "black"
    im_out = Image.new("RGB", tuple(im_out_size), bg_color)
    draw = ImageDraw.Draw(im_out)

    # Draw text
    y = 0
    for i, line in enumerate(ascii):
        for j, ch in enumerate(line):
            color = tuple(im_color[i, j])  # sample color from original image
            draw.text((letter_size[0] * j, y), ch[0], fill=color, font=font)
        y += letter_size[1]  # increase y by letter height

    # Save image file
    im_out_width = im_out_size[0] - 1 if im_out_size[0] & 1 else im_out_size[0]
    im_out_height = im_out_size[1] - \
        1 if im_out_size[1] & 1 else im_out_size[1]
    # resize image with high-quality
    im_outf = im_out.resize((im_out_width, im_out_height), Image.ANTIALIAS)
    im_outf.save("test_out/" + file.split('.')[0].split('/')[1] + "_ascii.jpg")


def pics_to_ascii():
    # 创建存储字符帧序列文件夹
    os.mkdir("test_out")
    path = "./test_origin/"
    files = os.listdir(path)
    for filename in files:
        #print("origin/" + filename)
        ascii_art("test_origin/" + filename)

# ffmpeg -i 输入文件夹路径(%04d.jpg) -c:v libx264 -vf fps=30 -pix_fmt yuv420p 输出文件路径(eg.out.mp4)


def asciipic_to_video():
    # 执行ffmpeg命令，30对应帧数
    ff = FFmpeg(inputs={'test_out/%04d_ascii.jpg': None}, outputs={
                'test_out.mp4': ['-c:v', 'libx264', '-vf', 'fps=30', '-pix_fmt', 'yuv420p']})
    ff.run()


if __name__ == "__main__":
    video_to_frames(str(sys.argv[1]))
    pics_to_ascii()
    asciipic_to_video()
    shutil.rmtree('test_origin')
    shutil.rmtree('test_out')
