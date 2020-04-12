# 拓展欧几里得

#### 普通gcd
```
int gcd(int a, int b)
{
	return b ? gcd(b, a%b) : a;
}
```

## exgcd的两大用处
* 求解方程ax+by=gcd(a,b),其中inv求逆元最常用
* 求解方程ax+by=c,由以上解法可推得

## 1. 逆元运用
```
#define long long LL
LL gcd(LL a, LL b) {
	return b == 0 ? a : gcd(b, a % b);
}

LL exgcd(LL a, LL b, LL &x, LL &y) {
	if (b == 0) { x = 1, y = 0; return a; }
	LL r = exgcd(b, a % b, x, y), tmp;
	tmp = x; x = y; y = tmp - (a / b) * y;
	return r;
}

LL inv(LL a, LL b) {
	LL r = exgcd(a, b, x, y);
	while (x < 0) x += b;//a,b互质
	return x;
}
```

### 注意：
inv(a,b)返回的x满足a*x=1(mod b)
即a\*x+b\*y=1,则方程有解的条件为1%gcd(a,b),即a,b互质才有逆元
由于a,b互质，gcd(a,b)=1,原方程即为ax+by=gcd(a,b)
求出解集中$x=x0+k*\frac{b}{gcd(a,b)},y=y0-k*\frac{a}{gcd(a,b)}$,k为任意整数。这里gcd(a,b)=1,则对x直接加减b即可，y同理。
则当x0<0时，要增至正数，可直接做 (x%b+b)%b,也可按上述循环做


#### 补充：逆元的其他求法


##### (1).逆元的递推式
**求a在模p的逆元x：a*x=1(mod p)**
**令p=k*a+r,则k=p/a,r=p%a**
**k*a+r=0(mod p)**
**k*inv[r]+inv[a]=0(mod p)**（两边同除以xr)
**inv[a]=-k\*inv[r]=(-p/a+p)\*inv[p%a]%p(mod p)**
**则可以上式作递推与递归处理，边界为inv[1]=1**

* 递推应用：预处理，线性表打表求逆元,只要求Mod是素数，O(n)(只针对一个模)
```
const long long mod = 1e9 + 7;
const int maxn1 = 1e5;
long long inv[maxn1 + 10];
void getInv()
{
	inv[1] = 1;
	for (long long i = 2; i <= maxn1; i++)
	{
		inv[i] = (mod - mod / i)*inv[mod%i] % mod;
	}
	return;
}
```

* 递归应用：单个函数求mod下的逆元
```
ll inv(ll b) 
{ 
	return b == 1 || b == 0 ? 1 : (mod - mod / b)*inv(mod%b) % mod; 
}
```

##### (2).逆元的费马小定理/欧拉定理求法
**费马小定理：若p为质数，$a^{p-1}$&equiv;1(mod p) ,则inv[a]=$a^{p-2}$**
**欧拉定理：若a,p互素，则有$a^{\varphi(p)}$&equiv;1(mod p),则inv[a]=$a^{\varphi(p)-1}$**
一般要是合数，我们直接用拓展欧几里得求，就不必再求欧拉函数
若p是质数，则可以按照费马小定理用快速幂求出相应逆元
```
int inv(int x, int p = mod - 2, int mul = 1)//相当于快速幂x^p
{
	for (; p; p >>= 1,x=1ll*x*x%mod)
	{
		if (p & 1)
		{
			mul = 1ll * mul*x%mod;
		}
	}
	return mul;
}
```
## 2. 任意线性方程

```
bool LinearEqu(int a, int b, int c, int &x, int &y)
{
	int d = exgcd(a, b, x, y);
	if (c%d == 0)
	{
		int k = c / d;
		x *= k;
		y *= k;//这里的x,y均为方程的一组特解
		return true;
	}
	return false;
}
```
### 注意：
d为exgcd的返回值，即gcd(a,b)
方程的特解为$x0=x_0*\frac{c}{gcd(a,b)},y0=y_0*\frac{c}{gcd(a,b)}$
方程的解集为$x=x0+k*\frac{b}{gcd(a,b)},y=y0-k*\frac{a}{gcd(a,b)}$,k为任意整数

---

# 中国剩余定理及其拓展

##### 中国剩余定理和扩展中国剩余定理的参数均为"除数列表m[]"和"余数列表c[]"
$x_1=c_1(mod\quad m_1)$
$x_2=c_2(mod\quad m_2)$
……
$x_n=c_n(mod\quad m_n)$


1.中国剩余定理用的是ecgcd,需要保证所有除数两两互质

```
int China(int p[], int a[])//p为除数列表，c为余数列表
{
	int ans = 0;
	for (int i = 0; i < N; i++)
	{
		PP *= p[i];
	}
	for (int i = 0; i < N; i++)
	{
		int W = PP / p[i];
		ans = (ans + a[i] * W*inv(W, p[i])) % PP;
	}
	return ans;
}
```

2. 扩展中国剩余定理用的是构造合并，不用保证两两互质
对于两个方程
$x_1=c_1(mod\quad m_1)$
$x_2=c_2(mod\quad m_2)$
可以合并为一个方程
$x=c(mod\quad m)$
其中c=
$((inv(\frac{m_1}{gcd(m_1,m_2)},\frac{m_2}{gcd(m_1,m_2)})*\frac{c2-c1}{gcd(m_1,m_2)})\% \frac{m_2}{gcd(m_1,m_2)})*m_1+c_1$
m=$\frac{m_1*m_2}{gcd(m_1,m_2)}$
按照这个递推完全部元素即可
```
int gcd(int a, int b)
{
	return b ? gcd(b, a%b) : a;
}

for (LL i = 1; i <= K; i++) scanf("%lld%lld", &M[i], &C[i]);
		bool flag = 1;
		for (LL i = 2; i <= K; i++) //m为除数列表，c为余数列表
		{
			LL M1 = M[i - 1], M2 = M[i], C2 = C[i], C1 = C[i - 1], T = gcd(M1, M2);
			if ((C2 - C1) % T != 0) { flag = 0; break; }
			M[i] = (M1 * M2) / T;
			C[i] = (inv(M1 / T, M2 / T) * (C2 - C1) / T) % (M2 / T) * M1 + C1;
			C[i] = (C[i] % M[i] + M[i]) % M[i];
		}
		printf("%lld\n", flag ? C[K] : -1);
```


### 注意：
两个算法返回的都是满足所有同余方程的最小值（包括0）
则扩展解集为ans+$lcm(m_1,m_2,\dots,m_n)$,lcm为最小公倍数
需要多个答案时应从解集中取