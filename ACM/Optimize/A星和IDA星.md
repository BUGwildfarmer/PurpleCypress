https://b.big-news.cn/2019/06/26/A-star与IDA-star算法/
1.A*(优化朴素的bfs)
```
const int CN=3010;

const int dx[4]={0,0,1,-1}; //方位数组
const int dy[4]={1,-1,0,0};

class locat{ //坐标
  public: int x,y;
  bool exm(int n,int m){
  	return (x>=1&&x<=n&&y>=1&&y<=m);
  }
};

//v deifne
int n,m,p;
bool vis[CN][CN]; //标记位

int abs(int a) {return a>0 ? a:-a;}

//A*
int dist(locat a,locat b){ //返回曼哈顿距离
    return abs(a.x-b.x)+abs(a.y-b.y);
}
class state{ //每个状态（节点）
  public: 
    int g,h; //距离函数和估价函数
    locat pos; //坐标
    bool operator < (const state &a)const 
    {return g+h > a.g+a.h;} //为了用priority_queue
}cur,fin; //当前状态和最终状态
priority_queue<state> Q;
int A_star(){
    cur.h = dist(cur.pos, fin.pos); //计算估价
    Q.push(cur);
    
    while(!Q.empty()){
        cur = Q.top(); //取最小
        Q.pop();
        
		if(vis[cur.pos.x][cur.pos.y]) continue;
        vis[cur.pos.x][cur.pos.y] = true;
        
        if(!dist(cur.pos,fin.pos)) break; //到达终点
        
        for(int k=0;k<4;k++){
            state nxt; //计算下一个状态
            nxt.pos.x = cur.pos.x+dx[k];
            nxt.pos.y = cur.pos.y+dy[k];
            nxt.g = cur.g+1; //步数+1
            nxt.h = dist(nxt.pos,fin.pos); //重新计算估价
            
            if(nxt.pos.exm(n,m) && !vis[nxt.pos.x][nxt.pos.y]) //最优性剪枝 
            	Q.push(nxt);
        }
    }
    
    return cur.g;
}

int main()
{
    ... //scan
    A_star();
    ... //print
    return 0;
}
```
---
2. IDA*(第二代加深的A*算法)
八数码问题
```
/* IDA* */
#include<iostream>
#include<cstdio>
#include<cstring>
#include<string>
using namespace std;

const int dx[4] = {1,-1,0,0};
const int dy[4] = {0,0,1,-1};

class locat{ //坐标
  public: int x,y;
    void init(int xx,int yy) {x=xx; y=yy;}
    bool exm() {return (x<=3&&x>=1&&y<=3&&y>=1);} //判断是否在棋盘内
    bool operator !=(const locat &a)const {return (a.x!=x||a.y!=y);} //判断坐标是否相同
};

//v define
int cur[4][4],fin[4][4],ans=0; //cur[][]: 当前状态 ; fin[][]: 最终状态

locat find_loc(int v){ //找值为v的元素的坐标
    for(int i=1;i<=3;i++)
        for(int j=1;j<=3;j++)
            if(cur[i][j] == v)
                return (locat){i,j};
    return (locat){0,0};
}

//IDDFS
int mxd=1; //深度限制
int h(){ //估价函数 
    int incor=0; //incorrect
    for(int i=1;i<=3;i++)
        for(int j=1;j<=3;j++)
            if(cur[i][j] != fin[i][j])
                incor++;
    return incor;
}
bool dfs(int d,locat u,locat prv){
    if(d == mxd) return !h(); //到达深度限制，检查是否是最终状态
    if(d+h()-1 > mxd) return false; //A*剪枝 
    for(int k=0;k<4;k++){
        locat v;
        v.init(u.x+dx[k],u.y+dy[k]); //计算下一个0的位置
        if(v.exm() && prv!=v){ //最优性剪枝
            swap(cur[v.x][v.y], cur[u.x][u.y]); //调换
            if(dfs(d+1,v,u)) return true; //到达最终状态，继续返回true
            swap(cur[v.x][v.y], cur[u.x][u.y]); //回溯
        }
    }
    return false; //未到达最终状态
}

int main()
{
    fin[1][1] = 1; fin[1][2] = 2; fin[1][3] = 3;
    fin[2][1] = 8; fin[2][2] = 0; fin[2][3] = 4;
    fin[3][1] = 7; fin[3][2] = 6; fin[3][3] = 5;
    
    for(int i=1;i<=3;i++)
        for(int j=1;j<=3;j++){
        	char c; cin>>c;
        	cur[i][j] = c-'0';
        }
    
    if(h()){
        while(!dfs(0,find_loc(0),(locat){0,0})) //迭代加深
            mxd++;
        printf("%d",mxd); //输出深度限制
    }   
    else printf("0");	
    
    return 0;
}
```