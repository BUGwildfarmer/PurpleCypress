<!-- <img src=".\pic\say_yolo_again.png"> -->
![](pic/say_yolo_again.png)

## YOLO学习笔记

### 1.yolo v1

> 论文来源：2016CVPR
> You Only Look Once:Unified,Real-Time Object Detection
> [参考网站](https://pjreddie.com/darknet/yolo/)

#### 1.1 基本思想：

(1)将一幅图像分成 $S \times S$ 个网格(grid cell)，如果某个 object 的中心落在网格之中，则这个网格就负责预测这个 object 。

(2)每个网格预测 **B** 个 bounding box ，每个 bouding box 除了要预测位置 `(x,y,w,h)` 外，还要附带一个 `confidence` 值（ yolo 独有， Faster-RCNN 和 SSD 没有），同时还要预测 **C** 个类别的分数。

> eg.Pascal VOC:Our Fianl Prediction is a 7 \* 7 \* 30 tensor.
> S = 7 ( grid cell 为 7 \* 7 )
> B = 2 ( 2 个 bounding box ,每个包含 x , y , w , h , confidence )
> C = 20 ( classes_num = 20 )
> 7 \* 7 \* (2 \* 5 + 10) -> 7 \* 7 \* 30


<!-- <img src=".\pic\yolov1_cell.png"> -->
![](pic/yolov1_cell.png)

> 每个 bouding box 的坐标是相对值，取值在[0,1]
> x,y : the center of the box **relative to the bounds of the grid cell**
> w,h : the width and height **relative to the whole image**
> confidence : $Pr(Object) \times IOU_{pred}^{truth}$ ,前者为 0 或 1 ，后者为预测框和实际框的交并比


(3)网络结构

 yolov1 的网络结构并不复杂，如下图所示

`其中 s 为步距 stride 的简写，未写的默认为 1 `

<!-- <img src=".\pic\yolov1_net.png"> -->
![](pic/yolov1_net.png)

最后两层： 4096 -> 1470 ->( reshape 处理) 7  \* 7 \* 30  （即上述的 cell 结构）

#### 1.2 损失函数

> yolov1 的损失函数由三部分组成,所用方法为误差平方和
> (1) bouding box loss
> (2) confidence loss
> (3) classes loss

<img src=".\pic\yolov1_lossfuction.png">

==tips:==

(1) bouding box 损失中的宽高损失计算需要**开根号**，目的是**防止不同尺寸的目标框偏移相同距离时的 loss 值一样**（偏移相同的距离，对于大目标而言， IoU 较大，则loss值应该相对较低；对于小目标而言， IoU 较小，则loss值应该相对较高，故采用开根可以起到如此效果）

<!-- <img src=".\pic\yolov1_boundingboxloss.png"> -->
![](pic/yolov1_boundingboxloss.png)

(2) confidence 损失计算中分为正样本和负样本的计算，根据正负样本真实值 $ \hat{C_i}$ 取 1 或 0 

#### 1.3 局限性

(1) 群体性目标难预测，例如一群飞鸟，不适合密集性对象

(2) 当目标出现新的尺寸或配置时，预测性能较差

(3) 定位不准确是主要问题（缺少 anchor ）

### 2.yolo v2

> 论文来源：2017CVPR 
> YOLO9000:Better,Faster,Stronger
> [参考网站](http://pjreddie.com/yolo9000/)

#### 2.1 改进

(1) Batch Normalization : 在每个卷积层后都增加了BN层

* 更好收敛
* 减少其他形式的正则化处理
* 可以替代 dropout 操作（防止过拟合）

(2) High Resolution Classifier : 224 * 224 -> 448 * 448

(3) Convolutinal With Anchor Boxes ：小幅度降低了 mAP ，但大幅提升了召回率（查全率）

(4) Dimention Cluster : 基于训练集采用 k-means 聚类的方法得到 anchor(priors) 

(5) Direct Location prediction : 使每个 anchor(prior) 去预测目标中心落在某个 grid cell 区域内的目标(防止加上预测偏移量会导致建议框出现在图片任意一个地方)，网络更易于学习和更加稳定

(6) Fine-Grained Features : 对于小目标的预测，同时融合了高层和低层的特征层，增加了 **passthrough layer** 的处理

(7) Multi-Scale Training ：每迭代 10 个 batch ，就改变输入尺寸的大小，尺寸均为 32 的整数倍，范围在{320,352，……,608}

#### 2.2 网络结构

![](pic/yolov2_net.png)

* 图中的每个 convolutional 都是由`卷积层(Conv2D)、 BN 层、激活函数(LeakyReLU)`组成，最后一层只有一个单卷积层作为预测器
*  Size 中未标步距的默认为 1 
*  backbone 中的 Darknet19 (由 19 个卷积层) 移除了最后一层卷积层及其之后的层，后面添加了 3 个 `3 * 3 的 1024 核卷积层`
*  最后预测的 125 个参数即为 5 个 boundingbox ，其中包括 `x , y , w , h , confidence `,以及 `20 个类别`
*  PassThrough Layer 作为高低层的特征层融合途径，其中 26 * 26 * 64 变成 13 * 13 * 256 的原理如下图所示
  
![](pic/yolov2_passthroughlayer.png)

### 3.yolo v3

> 论文来源： 2018CVPR
> YOLOv3: An Incremental Improvement

#### 3.1  backbone 结构( darknet53 )

![](pic/yolov3_darknet53.png)

* 53个卷积层（包括最后的 Connnected ），其中 convolutianl 均由`卷积层， BN 层，激活函数(LeakyRelu)`组成，残差结构均为`主分支和捷径分支`的相加结构
* 没有 maxpolling 层，下采样均由卷积层处理( size 为 2 )

#### 3.2 模型结构

![](pic/yolov3_net.jpg)

*  yolov3 在 3 个特征层进行预测，每个特征层采用 3 种尺度的 bounding box priors (即 anchor ,同样基于 k-means 聚类),参数如下图所示：
  
![](pic/yolov3_boundingbox_parameters.png)

每个特征层的预测参数个数为 $ N \times N \times [3 * (4 + 1 + 80)] $ ,其中 80 为种类数（ CoCo 数据集）

*  Up Sampling 为上采样层，高和宽会扩大为原来的 2 倍，扩大后便可与原来低层的输出进行 concatenate ，即进行深度上的拼接（ 13 -> 26 -> 52 ）
*  特征图 1 尺寸为 13 * 13,用来预测相对较大的目标；特征图 2 尺寸为 26 * 26,用来预测大小中等的目标；特征图 3 尺寸为 52 * 52，用来预测相对较小的目标

#### 3.3 目标边界框的预测与正负样本匹配

![](pic/yolov3_boundingboxpredict.png)

> $ \sigma $ 函数即为 sigmoid 函数，将预测的增量限制在一定范围使 anchor 不会超出对应的 grid cell 

与 ground truth 的 重合度最大的 bounding box 定为正样本，重合度不是最大但大于阈值的则忽视（不作为样本，即不计算目标框损失 loss for coordinate prediction 和类别损失 loss for class prediction ,仅计算置信度 objectness ），其余的则为负样本


#### 3.4 损失函数

>  YOLOv3 的损失函数主要分为 3 个部分：目标置信度损失 $L_{conf}(o,c)$ ,目标分类损失 $L_{cla}(O,C)$ 和目标定位偏移量损失 $L_{loc}(l,g)$ , $\lambda_1,\lambda_2,\lambda_3$ 为平衡系数
>  $L(O,o,C,c,l,g) = \lambda_1 L_{conf}(o,c) + \lambda_2 L_{cla}(O,C) + \lambda_3 L_{loc}(l,g)$

##### 3.4.1 目标置信度损失（二值交叉熵）

> $L_{conf}(o,c)=- \frac{\sum_i(o_i ln(\hat{c_i})+(1-o_i) ln(1-\hat{c_i}))}{N}$
> $\hat{c_i}=sigmoid(c_i)$

$o_i \in [0,1]$,表示目标边界与真实边界(ground truth)的 IoU ,c 为预测值， $\hat{c_i}$ 为 c 通过 sigmoid 函数得到的预测置信度， N 为正负样本个数

##### 3.4.2 目标类别损失（二值交叉熵）

> $L_{cla}(O,C) = - \frac{ \sum_{i \in pos} \sum_{j \in cla} (O_{ij} ln(\hat{C_{ij}}) + (1-O_{ij}) ln(1- \hat{C_{ij}}))}{N_{pos}} $
> $\hat{C_{ij}}=sigmoid(C_{ij})$

$O_{ij} \in {\{0,1\}}$，表示目标边界框 i 中是否存在第 j 类目标，$C_{ij}$ 为目标值,$\hat {C_{ij}}$ 为 $C_{ij}$ 通过 sigmoid 函数得到的目标概率， $N_{pos}$ 为正样本个数

##### 3.4.3 目标定位损失

![](pic/yolov3_boundingboxpredict.png)

> $L_{loc}(l,g) = \frac{ \sum_{i \in pos} \sum_{m \in \{x,y,w,h\}} (\hat{l_i^m}-\hat{g_i^m})^2}{N_{pos}}$
> $\hat{l_i^x}=Sigmoid(t_x),\hat{l_i^y}=Sigmoid(t_y)$
> $\hat{l_i^w}=t_w,\hat{l_i^h}=t_h$
> $\hat{g_i^x}=g_i^x-c_i^x,\hat{g_i^y}=g_i^y-c_i^y$
> $\hat{g_i^w}=ln(g_i^w/p_i^w),\hat{g_i^h}=ln(g_i^h/p_i^h)$

#### 3.5 yolov3 SPP

> yolov3-SPP-ultralytics 中有许多提升效能的 tricks

##### 3.5.1 Mosaic 图像增强

将若干个原图像进行拼接形成新图像，增强后一张图像的信息就包含原本多张图像的信息，有助于

（1） 增加数据的多样性
（2） 增加目标个数
（3） BN 能一次性统计多张图片的参数

##### 3.5.2 SPP模块

![](pic/yolov3_spp.png)

相比于原网络增加了` SPP 模块`（在原网络中的 convolutianal set 插入），包含 3 路最大池化层，将 4 路特征进行 concatenate 拼接(512->2048)

##### 3.5.3 损失函数的进化：CIoU Loss

(1) l2 :原 yolov3 采用的目标定位损失为 l2 损失

> $L_{loc}(l,g) = \frac{ \sum_{i \in pos} \sum_{m \in \{x,y,w,h\}} (\hat{l_i^m}-\hat{g_i^m})^2}{N_{pos}}$
> $\hat{l_i^x}=Sigmoid(t_x),\hat{l_i^y}=Sigmoid(t_y)$
> $\hat{l_i^w}=t_w,\hat{l_i^h}=t_h$
> $\hat{g_i^x}=g_i^x-c_i^x,\hat{g_i^y}=g_i^y-c_i^y$
> $\hat{g_i^w}=ln(g_i^w/p_i^w),\hat{g_i^h}=ln(g_i^h/p_i^h)$

会出现损失相同但 IoU 差距明显的的情况

![](pic/yolov3_l2same.png)

(2) IoU Loss = -ln IoU 或者 IoU Loss = 1 - IoU

能够更好地反应重合程度，具有尺度不变性，但当不相交时 loss 为 0 ，不符合实际情况

(3) GIoU Loss = 1 - GIoU

$GIoU = IoU - \frac{A^c-u}{A^c}$
$-1 \leq GIoU \leq 1$
$0 \leq GIoU Loss \leq 2$

![](pic/yolov3_GIoU.png)

其中，绿色矩形框为 ground truth ,红色矩形框预测框，蓝色矩形框为同时包含它们的最小矩形框， $A^c$ 则为蓝色矩形框面积。`当其重合时， GIoU = 1 ；当其相距无穷远时， GIoU = -1 `

(4) DIoU Loss = 1 - DIoU
$DIoU = IoU -\frac{\rho^2(b,b^{gt})}{c^2} = IoU - \frac{d^2}{c^2}$
$-1 \leq DIoU \leq 1 $
$0 \leq DIoU Loss \leq 2$

![](pic/yolov3_DIoU.png)

其中，$\rho^2(b,b^{gt})$ 即为预测框和 grounding box 中心点的欧氏距离 d ,  c 则为包含这两个框的最小矩形框的对角线长度。`DIoU损失能够直接最小化两个 boxes 之间的距离，因此收敛速度更快`

(5) CIoU Loss = 1 - CIoU
$CIoU = IoU - (\frac{\rho^2(b,b^{gt})}{c^2}+\alpha \upsilon)$
$\upsilon = \frac{4}{\pi^2}(\arctan \frac{w^{gt}}{h^{gt}}-\arctan \frac{w}{h})^2$
$\alpha = \frac{\upsilon}{(1-IoU)+\upsilon}$





