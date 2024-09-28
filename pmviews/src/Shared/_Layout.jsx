import '../Styles/_Layout.css'
import {Outlet, Link } from 'react-router-dom'
import { useState } from 'react';
import Header from './_Header';
import Footer from './_Footer';
function Layout() {
const [loggedIn,setLoggedIn] = useState();
  return (
      <div className='wrapper'>
      <div className='header'><Header/></div>
      <div className="navContainer">
            <nav>
              <ul id="linkList">
                <li>
                    <Link to="/products">Products</Link>
                  </li>
                  <li>
                    <Link to="/customers">Customers</Link>
                  </li>
                  <li>
                    <Link to="/orders">Orders</Link>
                  </li>
              </ul>
            </nav>
        </div>
        <div className="mainSection"><Outlet/></div>
        <div className='footer'><Footer/></div>
    </div>
  )
}

export default Layout
