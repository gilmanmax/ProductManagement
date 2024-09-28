import '../Styles/Products/ProductListing.css'

function ProductListing(props)
{
    return(
        <div className="product-card">
            <div className="product-name">{props.name}</div>
            <div className="product-desc">{props.description} </div>
            <div className='product-cost'> <span class="only">ONLY</span> ${props.unitCost}</div>
            <div className="product-img"><img src={props.imageURL}/></div>
            <div className='product-statusBtn'></div>
        </div>
    );
}

export default ProductListing;