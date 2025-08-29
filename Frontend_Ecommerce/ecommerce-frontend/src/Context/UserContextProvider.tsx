import React, { useState, type ReactNode } from 'react'
import UserContext from "./UserContext"



type UserContextProviderProps = {
  children: ReactNode;
};

function UserContextProvider({children}:UserContextProviderProps) {

    const[user,setUser] = useState(null)
    const[isDark,setIsDark] = useState(null)
    
  return (
    <UserContext.Provider value={{user,setUser,isDark,setIsDark}}>
        {children}
    </UserContext.Provider>
  )
}

export default UserContextProvider