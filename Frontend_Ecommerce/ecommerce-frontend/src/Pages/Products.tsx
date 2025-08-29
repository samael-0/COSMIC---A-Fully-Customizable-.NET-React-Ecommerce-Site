import React, { useEffect, useState } from 'react'
import ProductCard from '../components/ProductCard'
import { data } from 'react-router-dom'
import { Label } from '@radix-ui/themes/components/context-menu';


function Products() {
  const [products, setProducts] = useState([]);

// const fetchData =  () => {
//     const res =  fetch("api/Customer/getAllproducts")
//     .then((res)=>res.json())
//     .then((data)=>setProducts(data))


// };




// Call it inside useEffect
useEffect(() => {
    fetch("api/Customer/getAllproducts")
    .then((res)=>res.json())
    .then((data)=>setProducts(data))
}, []);



  return (
   
  //   <div className=' flex  gap-15 px-20 py-5 border-2 border-red-900 mt-[10rem] '>

 
  // {products.map((product) => 
  //   <ProductCard
  //     key={product.productId} 
  //     id={product.productId}
  //     name={product.name}
  //     price={product.price}
  //     imageOne={product.imageOne}
  //     imageTwo={product.imageTwo}
  //   />
  // )}



  //   </div>


  <div className=' min-h-screen dark:bg-primary-dark mt-[10rem] pt-[2rem]'>




    <div className=' grid grid-cols-4 gap-10 p-4' >
      {products.map((product) => 
    <ProductCard
      key={product.productId} 
      id={product.productId}
      name={product.name}
      price={product.price}
      imageOne={product.imageOne}
      imageTwo={product.imageTwo}
    />
  )}

  
   
   
    <ProductCard name='hello' imageOne='/Images/ProductImages/Product1ImgOne.jpeg' imageTwo='/Images/ProductImages/Product2ImgTwo.jpeg' price={1000}/>
     <ProductCard name='hello' imageOne='/Images/ProductImages/Product1ImgOne.jpeg' imageTwo='/Images/ProductImages/Product2ImgTwo.jpeg' price={1000}/>
      <ProductCard name='hello' imageOne='/Images/ProductImages/Product1ImgOne.jpeg' imageTwo='/Images/ProductImages/Product2ImgTwo.jpeg' price={1000}/>
       <ProductCard name='hello' imageOne='/Images/ProductImages/Product1ImgOne.jpeg' imageTwo='/Images/ProductImages/Product2ImgTwo.jpeg' price={1000}/>
        <ProductCard name='hello' imageOne='/Images/ProductImages/Product1ImgOne.jpeg' imageTwo='/Images/ProductImages/Product2ImgTwo.jpeg' price={1000}/>

         <ProductCard name='hello' imageOne='/Images/ProductImages/Product1ImgOne.jpeg' imageTwo='/Images/ProductImages/Product2ImgTwo.jpeg' price={1000}/>




    </div>
  </div>
  

  )
}

export default Products