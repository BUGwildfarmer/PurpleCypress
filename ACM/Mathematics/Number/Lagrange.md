拉格朗日插值，拉格朗日插值法可以找出一个恰好经过直角坐标系内n个给定点的函数
给n个点，确定一个多项式，并将k带入求和，结果对998244353求模
```
#pragma warning(disable:4996)
#include<cmath>
#include<cstdio>
#include<iostream>
using namespace std;
#define RI register int
#define CI const int&
using namespace std;
const int N = 2005, mod = 998244353;
int n, x[N], y[N], k;
inline int sub(CI x, CI y)
{
	int t = x - y; return t < 0 ? t + mod : t;
}
inline int inv(int x, int p = mod - 2, int mul = 1)
{
	for (; p; p >>= 1, x = 1LL * x*x%mod) if (p & 1) mul = 1LL * mul*x%mod; return mul;
}
inline int Lagrange(CI n, int *x, int *y, CI k)
{
	int ret = 0; 
	for (RI i = 1; i <= n; ++i)
	{
		int s1 = 1, s2 = 1; 
		for (RI j = 1; j <= n; ++j) 
			if (i != j)
			s1 = 1LL * s1*sub(k, x[j]) % mod, s2 = 1LL * s2*sub(x[i], x[j]) % mod;
		(ret += 1LL * y[i] * s1%mod*inv(s2) % mod) %= mod;
	}
	return ret;
}
int main()
{
	scanf("%d%d", &n, &k); 
	for (RI i = 1; i <= n; ++i) 
		scanf("%d%d", &x[i], &y[i]);
	printf("%d", Lagrange(n, x, y, k));
	system("pause");
	return 0;

}
```
---
求自然数幂和：i=(1,k)求和i^k,其通项公式必然是个k+1次多项式（带入k=1,2,3可得），之后便可用拉格朗日插值来做
```
#include <algorithm>
#include <cstdio>
using namespace std;

const int mo = 1e9 + 7;
const int N = 1e6 + 10;

int pl[N], pr[N], fac[N];

int qpow(int a, int b) {
	int ans = 1;
	for (; b >= 1; b >>= 1, a = 1ll * a * a % mo)
		if (b & 1) ans = 1ll * ans * a % mo;
	return ans;
}

int main() {
	int n, k, y = 0, ans = 0;
	scanf("%d%d", &n, &k);
	pl[0] = pr[k + 3] = fac[0] = 1;
	for (int i = 1; i <= k + 2; i++)
		pl[i] = 1ll * pl[i - 1] * (n - i) % mo;
	for (int i = k + 2; i >= 1; i--)
		pr[i] = 1ll * pr[i + 1] * (n - i) % mo;
	for (int i = 1; i <= k + 2; i++)
		fac[i] = 1ll * fac[i - 1] * i % mo;
	for (int i = 1; i <= k + 2; i++) {
		y = (y + qpow(i, k)) % mo;
		int a = pl[i - 1] * 1ll * pr[i + 1] % mo;
		int b = fac[i - 1] * ((k - i) & 1 ? -1ll : 1ll) * fac[k + 2 - i] % mo;
		ans = (ans + 1ll * y * a % mo * qpow(b, mo - 2) % mo) % mo;
	}
	printf("%d\n", (ans + mo) % mo);
	return 0;
}
```