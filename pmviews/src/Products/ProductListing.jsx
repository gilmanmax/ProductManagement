import '../Styles/Products/ProductListing.css'

function ProductListing(props)
{
    return(
        <div className="product-card">
            <div className="product-name">{props.name}</div>
            <div className="product-descCost">{props.description} <span className='product-unitPrice'> <span class="only">ONLY</span> ${props.unitCost}</span></div>
            <div className="product-img"><img src={props.imageURL}/></div>
        </div>
    );
}

export default ProductListing;