"""Type definitions for ARFlow."""

from __future__ import annotations

from dataclasses import dataclass
from typing import Dict, List, NewType

import numpy as np
import numpy.typing as npt

from arflow_grpc.service_pb2 import ClientConfiguration, DataFrame

ARFlowRequest = DataFrame | ClientConfiguration


@dataclass
class EnrichedARFlowRequest:
    """An enriched ARFlow request."""

    timestamp: float
    """The timestamp of the request."""
    data: ARFlowRequest
    """The ARFlow request data."""


ColorRGB = npt.NDArray[np.uint8]
DepthImg = npt.NDArray[np.float32 | np.uint16]
Transform = npt.NDArray[np.float32]
Intrinsic = npt.NDArray[np.float32]
PointCloudPCD = npt.NDArray[np.float32]
PointCloudCLR = npt.NDArray[np.uint8]


@dataclass
class DecodedDataFrame:
    """A decoded data frame."""

    color_rgb: ColorRGB
    """The color image in RGB format."""
    depth_img: DepthImg
    """The depth image. f32 for iOS, u16 for Android."""
    transform: Transform
    """The transformation matrix of the camera."""
    intrinsic: Intrinsic
    """The intrinsic matrix of the camera."""
    point_cloud_pcd: PointCloudPCD
    """The point cloud in PCD format."""
    point_cloud_clr: PointCloudCLR
    """The point cloud colors in RGB format."""


RequestsHistory = List[EnrichedARFlowRequest]
HashableClientIdentifier = NewType("HashableClientIdentifier", str)
"""This should match a hashable field in the `ClientConfiguration` message."""
ClientConfigurations = Dict[HashableClientIdentifier, ClientConfiguration]