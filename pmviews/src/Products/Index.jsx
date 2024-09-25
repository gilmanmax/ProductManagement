import { useEffect, useState } from "react";
import axios, { Axios } from "axios";
import ProductListing from "./ProductListing"
function Products()
{
    const [pageSize, setPageSize] = useState();
    const [currentPage, setCurrentPage] = useState();
    const [data, setData] = useState([]);
    useEffect(()=>{
        GetProducts(1,25);
    },[data]);
 
    const rows = data.map((product, index)=>{
        const shouldStartNewRow = (index + 1) % 3 === 0;
        return (
            <div key={product.id} className="product-item">
                <ProductListing {...product}/>
                {shouldStartNewRow && <div className="product-row-end" />}
            </div>
        );
    });
    
    function GetProducts(currentPage, pageSize){
        axios
        .get("https://localhost:7279/api/Product/List/"+ currentPage+ "/" + pageSize)
        .then((res)=>{
            setData(res.data);
        });
    }

    return (
        <>
        <div id="pageTitle">Product Listings</div>
        <div id="productContainer">
            {rows}
        </div>
        </>
    );
}

export default Products