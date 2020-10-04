import React, {useContext} from "react";
import appsettings from '../appsettings.json'

export const AppSettingsContext = React.createContext(appsettings)

export function useAppSettings(){
    const context = useContext(AppSettingsContext);
    return context;
}
