import { useEffect, useState } from "react";
import axios, { Axios } from "axios";
import ProductListing from "./ProductListing";
import "../Styles/Products/index.css";
function Products()
{
    const RECORDS_PER_ROW = 2;
    const [pageSize, setPageSize] = useState();
    const [currentPage, setCurrentPage] = useState();
    const [data, setData] = useState([]);
    useEffect(()=>{
        GetProducts(1,25);
    },[currentPage,pageSize]);

    
    const rows = data.map((product, index)=>{
        const shouldStartNewRow = (index + 1) % RECORDS_PER_ROW === 0; 
        return (
            <div key={product.id} className="product-item">
                <ProductListing {...product}/>
                {shouldStartNewRow && <div className="product-row-end" />}
            </div>
        );
    });
    
    function GetProducts(currentPage, pageSize){
        axios
        .get(`https://localhost:7279/api/Product/List/${currentPage} / ${pageSize}`)
        .then((res)=>{
            setData(res.data);
        });
    }

    return (
        <>
        <div className="pageTitle">Product Listings</div>
        <div className="addBtn"><span className="plus"></span>Add New Product</div>
        <div className="productContainer">
            {rows}
        </div>
        </>
    );
}

export default Products