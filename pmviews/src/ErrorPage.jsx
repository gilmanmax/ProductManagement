import { useRouteError } from "react-router-dom";


export default function ErrorPage(){
    const error = useRouteError();
    console.error(error);

    return(
        <div>
            <h1>Four-Oh-Four</h1>
            <p>You have reached yet another 404 page. Sorry! </p>
            <p>
                <i>{error.statusText || error.message} </i>
            </p>
        </div>
    );
}