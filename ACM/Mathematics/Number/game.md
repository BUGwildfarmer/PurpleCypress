# 博弈论

##### 核心：寻找必败状态（任何人面对必败状态下都是必败，即奇异面前先手必亡）
必败状态特点：
* 任何必败状态经一次操作后必然变成非必败状态，否则就变成对方面对必败状态，那就不是必败
* 非必败态一定可以移动到必败态，故对于一局博弈和足够聪明的玩家来说，开局状态和先后次序就已经知道谁胜谁负

---

### 常见博弈类型及其必败态分析

#### 1.巴什博弈（Bash Game)
特点：
* 对象是一堆石子
* n个石子，两人轮流取，至少为1，至多为m，取光者胜

**巴什博弈的必败态：n%(m+1)==0**
分析：一旦石头个数成为（m+1)的倍数（倘若至少为p，则将1换为p），先手取多少，后手都可以凑成（m+p)使得剩下的石头个数仍是必败状态，直到取完，先手失败。


#### 2.威佐夫博弈（Wythoff Game）
特点：
* 对象是两堆石子
* 两个人轮流取，从任一堆取至少一个或者两堆取同样多的石子，至少取一个，多者不限，取光者胜

**威佐夫博弈的必败态：$a=(b-a)*\frac{\sqrt{5}+1}{2},b=a+(b-a)$**
分析：威佐夫序列对（即博弈必败态）
(0,0),(1,2),(3,5),(4,7),(6,10),(8,13),(9,15),(11,18)……
(ai,bi),ai为前面未出现过的最小整数，bi=ai+k,k为自然数0,1,2,3……
该序列对的规律便可由必败态公式中的**黄金分割比**来写


#### 3.尼姆博弈（Nim Game)
特点：
* 对象是若干堆石子
* 两个人轮流取，从某一堆中取任意多石子，至少为1，多者不限

**尼姆博弈的必败态：各队石子数目的异或和为0（$x_1 \bigoplus x_2 \bigoplus x_3…… \bigoplus x_n==0$）**
分析：略
##### 拓展变换：
（1） **普通类型**：判断胜利者，直接根据异或和判断
（2） **先取完者判输**：统计所有大于1的堆的个数num，再求异或和jud（改变必败状态:奇数个1）
```
if(((num==0)&&(jud==0)) || ((num>0)&&(jud!=0)))  先手胜
else 后手胜
```
（3） **限制最多取的个数**：改变石子数量
&emsp;&emsp;&emsp;第i堆石子有m个，最多取r个，做**m=m%(r+1)**,再按普通类型做（异或和）
（4） **先手的人想赢，第一步有多少种选择**：
首先求出所有堆异或后的值sum，再用这个值去对每一个堆进行异或
**对任一堆$x_i,res=sum \bigoplus x_i$**
如果$res < x_i$的话，当前玩家就从$x_i$中取走$（x_i - res）$个，使得剩下的必然导致所有的堆的异或值为0，也就是必败点（达到奇异局势），这就是一种方案。
遍历每一个堆，进行上面的断判就可以得到总的方案数。


---

## 总结：
各种类型的博弈问题：分类，寻找不同类型下的**必败状态**
**对于二元状态来说，可以通过递推：**
* 凡能转移到一个必败态的状态为必胜态
* 能转移到的所有状态都是必胜态的状态则为必败态

对于普通博弈，常用的是寻找必败态然后递推
对于博弈规律，需要应用相应的状态规律，比如求胜利者、求方案数、求胜利路径等等
博弈问题可以转成棋盘问题，如下题所示

#### 样例：
有一个n*m的棋盘，棋子初始位置为(1,1),要走到（n,m),两个人轮流走，B先手G后手，棋子的规则有四种：（1）king国王（只能走周围把八个格子）；（2）rook车（只能走直线）；（3）knight马（只能走“日”字）；（4）quuen皇后（走直线和斜线）
规定每一次走必须至少满足向右或向下，即（x,y)下一个点（x',y')需满足x'>=x,y'>=y
输出胜利者
输入：（样例个数;棋子类型,n,m)
4
1 5 5
2 5 5
3 5 5
4 5 5
输出：（胜利者G或B,平手则为D）
G
G
D
B
```
#pragma warning(disable:4996)
#include <iostream>
#include <cstdio>
#include <string.h>
#include <cmath>
#include<algorithm>
#define LL long long
#define d (sqrt(5)+1)/2　//黄金比例
using namespace std;
int main()
{
	int t, type, n, m;
	cin >> t;
	while (t--)
	{
		scanf("%d%d%d", &type, &n, &m);
		if (m > 1000 || n > 1000 || n < 2 || m < 2)
			continue;
		n--, m--;
		if (type == 1)//王穷举
		{
			if (n % 2 == 0 && m % 2 == 0)
				printf("G\n");
			else
				printf("B\n");
		}
		if (type == 2)//车尼姆博弈
		{
			if (n == m)
			{
				printf("G\n");
			}
			else
				printf("B\n");
		}
		if (type == 3)//马
			//因为只能向右下走所以有两种走法，左１右２，和左２右１；棋盘内有的是可以到达且到达的步数是不变的，分别设走１的k1步,第２种走法的为k2步;
			//可以有方程k1*1+k2*2=m,k1*2+k2*1=n;联立求解，若k1,k2为正整数则能分出胜负；
			//根据奇偶求胜负。但是还有一点要注意，因为谁都不想输所以要输的人尽量走成平局，这种情况需判断k1与k2间之差大于等于２；大于２就是平局，不难推出。
		{
			if ((2 * n - m) / 3 * 3 == 2 * n - m && (2 * m - n) / 3 * 3 == 2 * m - n)
			{
				int k1 = (2 * n - m) / 3;
				int k2 = (2 * m - n) / 3;
				int k = k2 + k1;
				if (abs(k1 - k2) > 1)
				{
					printf("D\n");
					continue;
				}
				else if (k % 2 == 0)//奇偶性判断胜方
				{
					printf("G\n");
				}
				else
					printf("B\n");
			}
			else
				printf("D\n");
		}
		if (type == 4)
		{
			if ((int)(abs(n - m)*((sqrt(5) + 1) / 2)) == min(n, m))//威佐夫博弈
			{
				printf("G\n");
			}
			else
				printf("B\n");
		}
	}
	return 0;
}
```