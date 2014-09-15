﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace ImageResizer.Plugins.RemoteReader {

    /// <summary>
    /// delegate providing remote request to the Reader
    /// </summary>
    /// <param name="sender">sender of the request</param>
    /// <param name="args">Remote Request configuration</param>
    public delegate void RemoteRequest(object sender, RemoteRequestEventArgs args);

    /// <summary>
    /// Event args for RemoteRequest connection and configuration
    /// </summary>
    public class RemoteRequestEventArgs {

        private string remoteUrl = null;
        
        /// <summary>
        /// The url to the remotely hosted image.
        /// </summary>
        public string RemoteUrl {
            get { return remoteUrl; }
            set { remoteUrl = value; }
        }

        private NameValueCollection queryString = null;

        /// <summary>
        /// Resizing settings. These are not signed - other parties can manipulate them.
        /// </summary>
        public NameValueCollection QueryString {
            get { return queryString; }
            set { queryString = value; }
        }

        private bool signedRequest = false;
        /// <summary>
        /// True if the remote url was (correctly) signed with an HMAC SHA-256 to verify that it had not be altered since it was generated by the same server (or another server with the same key).
        /// </summary>
        public bool SignedRequest {
            get { return signedRequest; }
            set { signedRequest = value; }
        }

        /// <summary>
        /// True to deny the request
        /// </summary>
        private bool denyRequest = true;

        /// <summary>
        /// True to deny the request
        /// </summary>
        public bool DenyRequest {
            get { return denyRequest; }
            set { denyRequest = value; }
        }
    }
}
