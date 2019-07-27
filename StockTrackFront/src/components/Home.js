import React from 'react';

class Home extends React.Component{
    constuctor() {
        this.routeChange = this.routeChange.bind(this);
      }    

      routeChange = ()=> {
        let path = '/CreateAccount';
        this.props.history.push(path);
      } 

    render(){
        return(
            
          <div>
              {/*Header */}
    <section className="hero"id="intro">
        <div className="container">
            <div className="row d-flex align-items-center justify-content-center text-center">
                <div className="col-md-10">
                    <div className="title-content-warpper">
                        <h1>Stock Track online </h1>
                    </div>
                    <h4 className="mt-3 mb-3">Use the great built in search facilities  for any purpose. <br />Search stock - Asset manager – restaurant</h4>
                    <p>
                   
                        <button         
                        onClick={this.routeChange}
                        className="btn btn-lg btn-gradient"
                        >
                            Signup for free                            
                            </button></p>
                    <p><small> Get Updates Instantly</small></p>
                </div>
            </div>
             {/*intro feature box */}
            
            <div className="mt-5 mb-5">
                <div className="row text-center">
                    <div className="col-12 col-md-4">
                        <div className="feature-box">
                            <div className="mb-2">
                                <div className="icon display-3 mb-3"><i className="fab fa-meetup"></i></div>
                                <h5>Make sales available anywhere</h5>
                                <p>In the cloud your sales are available everywhere.</p>
                            </div>
                        </div>
                        {/***  end of Feture box **/}
                    </div>
                    <div className="col-12 col-md-4">
                        <div className="feature-box">
                            <div className="mb-2">
                                <div className="icon display-3 mb-3"><i className="fab fa-cloudversify"></i></div>
                                <h5>Cloud Stock Control</h5>
                                <p>Stock control in the cloud makes life easy for sales and reports.</p>
                            </div>
                        </div>
                        {/* end of Feture box */}
                    </div>
                    <div className="col-12 col-md-4">
                        <div className="feature-box">
                            <div className="mb-2">
                                <div className="icon display-3 mb-3"><i className="fab fa-lastfm"></i></div>
                                <h5>As Is</h5>
                                <p>Use as is out of the box. Add a product and sell it. Add company assets</p>
                            </div>
                        </div>
                        {/* end of Feture box */}
                    </div>
                </div>
            </div>
        </div>
    </section>

          </div>
        );
    }
}

export default Home;

