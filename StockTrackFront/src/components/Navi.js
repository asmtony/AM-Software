import React from 'react';
{/* import {withRouter, Link} from 'react-router-dom';*/}

class Navi extends React.Component{

    constuctor() {
        this.onLogIn = this.onLogIn.bind(this); 
      }

      onLogIn = () =>{
          alert('Login Here');
            let path = '/CreateAccount';
            this.props.history.push(path);
    }
    render(){
        return(
<div>
<nav id="mainNav" className="navbar navbar-expand-lg navbar-light">
                <div className="container">                   
                    <div className="collapse navbar-collapse" id="navbarResponsive">
                        <ul className="navbar-nav ml-auto">
                            
                        <li className="nav-item">
                            <button 
                            onClick={this.onLogIn} 
                            
                            className="navbar-brand js-scroll-trigger"
                            >Login New</button><br />
                            <Link to="/Login">Home</Link>
                        </li>
                        </ul>
                    </div>
                </div>
            </nav>
        </div>
        );
    }    
}

export  default Navi;