import { useState } from 'react'
import '../Styles/_Layout.css'
import {Outlet } from 'react-router-dom'

function Layout() {
  const [count, setCount] = useState(0)

  return (
    <div class="wrapper">
      <div className='header'></div>
        <div id="navContainer">
            <nav>
            <ul id="linkList">
                <li class="link"><a href="/products">Products</a></li>
                <li class="link"><a href="/customers">Customers</a></li>
                <li class="link"><a href="/orders">Orders</a></li>
            </ul>
            </nav>
        </div>
        <div className="mainSection"><Outlet/></div>
        <div className='footer'></div>
    </div>
  )
}

export default Layout
