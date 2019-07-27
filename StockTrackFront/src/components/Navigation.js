import React from 'react';
import {NavLink, Link} from 'react-router-dom';

class Navigation extends React.Component{

    constructor(props){
        super(props);
        this.loggedin = true;
        this.state = { loggedin: this.loggedin, buttonText: 'Logged In'  };
        this.divVisible = this.divVisible.bind(this);
    }

    divVisible = () => {
        const {loggedin} = this.state;
                   
        this.setState({loggedin : !loggedin});
        console.log(loggedin);

        if(loggedin) 
            this.setState({buttonText: 'Logged In'})
        else this.setState({buttonText: 'Not Logged In'})
    }

    render(){
        return(
            
            <div>
                 <button onClick={this.divVisible}>{this.state.buttonText}</button>
                {this.state.loggedin && <NavMenuNotLoggedIn />}
                {!this.state.loggedin && <NavMenuLoggedIn />}
               
          </div>
        );
    }
}

class NavMenuNotLoggedIn extends React.Component{

    render (){
        return (            
            <div>
                
                <nav id="mainNav" className="navbar navbar-expand-lg navbar-light">
                <div className="container">                   
                    <div id="navbarResponsive">
                        <ul className="navbar-nav ml-auto">
                        
                        <li className="nav-item">
                            <NavLink to='/' className="navbar-brand js-scroll-trigger">Home</NavLink><br />                    
                        </li>
                        <li className="nav-item">
                            <NavLink to='/createaccount' className="navbar-brand js-scroll-trigger">Create Account</NavLink>
                        </li>
                        <li className="nav-item">
                            <NavLink to='/login' className="navbar-brand js-scroll-trigger">Login</NavLink>
                        </li>
                        <li>
                        <a href="/login" className="nav-item">Login</a>
                        </li>
                        </ul>
                    </div>
                </div>
                </nav>
              
            </div>
        );
    }
}



class NavMenuLoggedIn extends React.Component{

    render (){
        return (            
            <div>
                
                <nav id="mainNav" className="navbar navbar-toggler navbar-expand{-sm|-md|-lg|-xl} navbar-expand-lg navbar-light">
                <div className="container">                   
                    <div id="navbarResponsive">
                        <ul className="navbar-nav ml-auto">
                        <li className="nav-item">
                            <NavLink to='/login' className="navbar-brand js-scroll-trigger">Add Product</NavLink><br />
                        </li>
                        <li className="nav-item">
                            <NavLink to='/' className="navbar-brand js-scroll-trigger">Settings</NavLink><br />
                        </li>
                        <li className="nav-item">
                            <NavLink to='/createaccount' className="navbar-brand js-scroll-trigger">Product List</NavLink>
                        </li>
                        </ul>
                    </div>
                </div>
                </nav>
              
            </div>
        );
    }
}

export default Navigation;

