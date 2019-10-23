import React from 'react';
import { connect } from 'react-redux';
import './Home.css';


const Home = () => {
    return (
        <div>
            <div className="firstNote">
                "Read Without Limits!"
            </div>
            <div className="secondNote">
                "Stay Curious!"
            </div>
            <div className="thirdNote">
                "There is always something new to discover!"
            </div>
            <div className="thirdNote">
                "Feed your brain, grab a bite to read!"
            </div>
            <div className="fourNote">
                "Reading is cool!"
            </div>
            <div className="fiveNote">
                "The prefect hideout is inside a book!"
            </div>
          
        </div>
    );
}

export default connect()(Home);
