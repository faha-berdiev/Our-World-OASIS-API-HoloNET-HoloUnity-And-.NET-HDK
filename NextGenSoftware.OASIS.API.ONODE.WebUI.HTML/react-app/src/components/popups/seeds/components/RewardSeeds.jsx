import React from 'react';

import { Modal } from 'react-bootstrap';

class RewardSeeds extends React.Component {
    render() {
        const { show, hide } = this.props;

        return (
            <>
                <Modal
                    centered
                    className="custom-modal custom-popup-component"
                    show={show}
                    onHide={() => hide('seeds', 'rewardSeeds')}
                >
                    <Modal.Body>
                        <span className="form-cross-icon" onClick={() => hide('seeds', 'rewardSeeds')}>
                            <i className="fa fa-times"></i>
                        </span>

                        <div className="popup-container default-popup">
                            <div className="seed-container paywith-seeds">
                                <h1 className="single-heading">
                                    Reward with Seeds
                                </h1>
                                <div className="form-container">
                                    <form>
                                        <p className="single-form-row">
                                            <label className="single-radio-btn">
                                                <input type="radio" id="html" name="fav_language" value="HTML" />
                                                Avatar
                                            </label>
                                            <input type="text" placeholder="username" />
                                        </p>

                                        <p className="single-form-row">
                                            <label className="single-radio-btn">
                                                <input type="radio" id="html" name="fav_language" value="HTML" />
                                                Seed Username
                                            </label>
                                            <input type="text" placeholder="username" />
                                        </p>

                                        <p className="single-form-row">
                                            <label>Amount</label>
                                            <input type="text" />
                                        </p>

                                        <p className="single-form-row mb-30">
                                            <label>Note</label>
                                            <input type="text" />
                                        </p>

                                        <p className="single-form-row btn-right">
                                            <button
                                                className="sm-button"
                                                type="submit"
                                            >Reward</button>
                                        </p>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </Modal.Body>
                </Modal>
            </>
        );
    }
}

export default RewardSeeds;