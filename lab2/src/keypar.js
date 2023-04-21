import Keycloak from "keycloak-js";

const client = new Keycloak({
    url: "http://localhost:8080/",
    realm: "schoolRealm",
    clientId: "FrontendClient",
});

export default client;