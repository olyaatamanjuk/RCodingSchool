library(strucchange)
library(fractal)
library(fracdiff)
library(pracma)

setwd("D:/PROJECT/RCodingSchool/RCodingSchool/App_Data/R/Calculate")

f <- file("stdin")
open(f)
input <- readLines(f, n = 1L)
params <- unlist(strsplit(input, " "))
print(params)

Data = read.csv('TestData.csv', header = TRUE, sep = ';')
head(Data[,2])
T = length(Data[,2])
N = as.double(params[1]) 
K = as.double(params[2]) 
L = floor(T/(N*K))

## Calculate Hurst index for intervals by MFDFA and GPH
Result_MF = c()
Result_GPH = c()

for (i in 1:(K*N)){
  if (i<K*N){
    data = Data[((i-1)*L+1):(i*L),2]
  } else {
    data = Data[((i-1)*L+1):T,2]
  }
 dfa = DFA(data, detrend="poly2")
 Result_MF[i] =  dfa[1]
 Result_GPH[i] = fdGPH(data)$d+0.5
}
 
Result_MF 
Result_GPH

RES = matrix(c(unlist(Result_MF),unlist(Result_GPH)), ncol =N*K )
rownames(RES) = c('MFDFA', 'GPH')
RES

## Hierarchial clustering
clusters <- hclust(dist(t(RES)))
plot(clusters)
clusterCut <- cutree(clusters, N)

## Plot data with color 
png(file="D:/PROJECT/RCodingSchool/RCodingSchool/Content/images/plots/current_plot.png", width=800, height=450)
for (i in 1:(K*N)){
  if (i<K*N){
    data = Data[((i-1)*L+1):(i*L),2]
    INT  = c(((i-1)*L+1):(i*L));
  } else {
    data = Data[((i-1)*L+1):T,2]
    INT  = c(((i-1)*L+1):T);
  }
  if (i==1){
    plot(INT, data, col = clusterCut[i],xlim = c(1,T) , 
        ylim = c(min(Data[,2])-1,max(Data[,2])+1), type = 'l', 
        main = 'івапрнвапвапр:',
     xlab = 'екуцекуцкуе:', ylab = 'івапівапіва:')
   } else {
    lines(INT, data, col = clusterCut[i] , type = 'l')
   }
 }

## Estimation of the P
P = matrix(0, ncol=N, nrow = N);
for (i in 1:N){
  for (j in 1:N){
     for (k in 1:(N*K-1)){
       if (clusterCut[k] == i & clusterCut[k+1] == j){
           P[i,j] = P[i,j] +1;
        }
     } 
  }
}

for (i in 1:N){
  P[i,] = P[i,]/sum(P[i,])
}

## Stationar distribution 
A = t(P - diag(N))
A[N,]=1

b = matrix(0, nrow = N, ncol = 1)
b[N,1] = 1

pi = solve(A,b)


## Calculation of the average H
H_DFA = c();
H_GPH = c();
FRAME = data.frame(t(RES))
for (i in 1:N){
   H_DFA[i] = mean(unlist(FRAME$MFDFA[clusterCut == i]), na.rm = TRUE)
   H_GPH[i] = mean(unlist(FRAME$GPH[clusterCut == i]), na.rm = TRUE)
}

"RESULTS:"
H_DFA 
H_GPH 

## Calculation average of H

DFA = sum(pi*H_DFA)
GPH = sum(pi*H_GPH)

c(DFA, GPH)