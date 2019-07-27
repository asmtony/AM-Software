import React from 'react';


class CreateAccount extends React.Component{

    logIn = () =>{
        alert('Login Here');
    }
    render(){
        return(
            <div>
<section className="space-md border-bottom bg-light" id="signup">
        <div className="mask bg-dark"></div>
        <div className="container">
            <div className="row d-flex justify-content-center text-center">
                <div className="col-lg-8">
                    <div className="w-85">
                        <h2 className=""> SignUp for a free  </h2>
                        <p className="lead">Free for small users</p>
                        <div className="row row d-flex justify-content-center mt-5">
                            <div className="col-md-8">
                                
                                <div className="form-message mb-3">
                                    <div className="input-group input-group form">
                                        <div className="input-group-prepend form__prepend"> <span className="input-group-text form__text">
                                                <span className="fa fa-envelope form__text-inner"></span> </span>
                                        </div>
                                        <input type="email" className="form-control form__input" name="signupEmail" required="" placeholder="Enter your email address" aria-label="Enter your email address" />
                                    </div>
                                </div>
                               
                                <div className="form-message mb-3">
                                    <div className="input-group input-group form">
                                        <div className="input-group-prepend form__prepend"> <span className="input-group-text form__text">
                                                <span className="fa fa-lock form__text-inner"></span> </span>
                                        </div>
                                        <input type="password" className="form-control form__input" name="signupPassword" required="" placeholder="Create your password" aria-label="Create your password" />
                                    </div>
                                </div>
                               
                                <div className="form-message mb-3">
                                    <div className="input-group input-group form">
                                        <div className="input-group-prepend form__prepend"> <span className="input-group-text form__text">
                                                <span className="fa fa-lock form__text-inner"></span> </span>
                                        </div>
                                        <input type="password" className="form-control form__input" name="signupPasswordCopy" required="" placeholder="Password again" aria-label="Password again" />
                                    </div>
                                </div>
                                
                                <div className="form-group text-left pt-2 pb-2">  </div>
                                <button 
                                    type="submit" 
                                    onClick={this.logIn}
                                    className="btn btn-block btn-gradient">Sign Up</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
                       
            </div>
        );
    }
}

export default CreateAccount;