import React from 'react';
import Loader from "react-loader-spinner";

type SkyLoaderPropType = {

}

function SkyLoader(props : SkyLoaderPropType) {
    return (
        <Loader type='Puff' width={200} height={200}/>
    );
}

export default SkyLoader;
