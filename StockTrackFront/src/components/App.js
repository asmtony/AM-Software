import React from 'react';
import {BrowserRouter as Router, Route, Link} from 'react-router-dom'; 

import Home from  './Home';
import CreateAccount from  './CreateAccount';
import Error from  './Error';
import Navigation from './Navigation'; 
import Login from './Login';
// Bootstrap Core CSS
import '.././css/VendSpec/vendor/bootstrap/css/bootstrap.min.css';
//Custom Fonts
import ".././css/VendSpec/vendor/fontawesome-free/css/all.min.css";
//import "https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,700,300italic,400italic,700italic";
import ".././css/VendSpec/vendor/simple-line-icons/css/simple-line-icons.css";
//Custom CSS
import ".././css/VendSpec/css/style.min.css";
import ".././css/VendSpec/css/custom.css";


class App extends React.Component{

    constructor(props){
        super(props);
        this.loggedin = true;
        this.state = { loggedin: this.loggedin };
        this.divVisible = this.divVisible.bind(this);
    }

    divVisible = () => {
        const {loggedin} = this.state;
        this.setState({loggedin : !loggedin})
    }

    render(){
        return(       
            <Router>      
              <Navigation />
              <Route exact path="/" component={Home} />
              <Route path="/login" component={Login} />
              <Route path="/createAccount" component={CreateAccount} />
              <Route exact component={Error}/>
          </Router>
          
        );
    }
}

export default App;
