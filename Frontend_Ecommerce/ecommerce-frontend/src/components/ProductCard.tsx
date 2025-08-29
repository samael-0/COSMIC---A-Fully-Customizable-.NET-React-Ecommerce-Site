import React, { useState } from 'react'
import product1 from "../assets/Images/productshowcase3.jpeg"
import product2 from "../assets/Images/productshowcase1.png"
import { Button } from '@radix-ui/themes';

type ProductCardProps = {
  id: number;
  name: string;
  imageOne: string;
  imageTwo:string;
  price:number;

};

function ProductCard({id,name,imageOne,imageTwo,price}:ProductCardProps) {


  const Images = [imageOne, imageTwo];
  const baseUrl = "https://localhost:7038";

const [currentImage,setCurrentImage]= useState(0)

const imgChange=()=>{
    setCurrentImage((prev)=>{
        const nxtImage = prev+1;
        if(nxtImage>=Images.length){
            return 0 ;
        }else{
        return nxtImage;
        }

    })

}

  return (
    <div className='flex w-[20rem] flex-col  items-center  border-2 border-red-500 rounded-2xl p-7 shadow-2xl shadow-primary-dark dark:shadow-primary  '>
        {/* <img src={Images[currentImage]} alt="product img"  className="" onMouseOut={imgChange} onMouseOver={imgChange}/> */}
        <img src={`${baseUrl}${Images[currentImage]}`} alt="product" className="" onMouseOut={imgChange} onMouseOver={imgChange} />
        <h1>{name}</h1>
        <p>{price}</p>
       <button className="px-6 py-2 rounded-xl bg-gradient-to-r from-cyan-700 to-cyan-900 
         text-amber-50 font-semibold shadow-md border-2 border-cyan-800 
         hover:from-cyan-600 hover:to-cyan-800 hover:shadow-lg 
         hover:scale-105 active:scale-95 transition-all duration-300 ease-in-out">buyNow</button>

    </div>
  )
}

export default ProductCard