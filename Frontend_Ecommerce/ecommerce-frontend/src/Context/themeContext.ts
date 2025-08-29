import { createContext,useContext } from "react";

export const ThemeContextt = createContext({
    themeMode:'light',
    darkTheme:()=>{},
    lightTheme:()=>{}

})

export const ThemeProvider = ThemeContextt.Provider
