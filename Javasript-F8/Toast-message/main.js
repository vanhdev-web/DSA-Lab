
var prices= [7,6,4,3,1]



let min = 0;
let max = 0;
let index = 0;
for (let i = 1; i< prices.length; i++){
    
    if ( prices[i] >= max){
        max = prices[i]
        index = i

    }
}

min = max
for ( let j = index-1; j> -1; j--){   
    
    if (prices[j] < min){
        min = prices[j]
   
    }
}

console.log(index)
console.log(max)
console.log(min)
console.log(max - min)