import React from 'react'
import productImg from '../assets/Images/productshowcase1.png';

function ProductView() {
  return (
    <div className=' flex justify-center mt-[10rem]'>
        <div className=' flex justify-between gap-7 w-[50rem]  p-4 border-2 border-rose-300'>
            <div className=''>
                <img className='w-[20rem]' src={productImg} alt="" />
            </div>

            <div className='flex flex-1 flex-col p-4 border-2 border-red-500'>
              <p className='text-[8px] text-b font-bold'>COSMICFITS</p>
                <h1>Product Name</h1>
                <h1>119$</h1>

                <p>Description</p>
            </div>
        </div>
    </div>
  )
}

export default ProductView